using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller
{
    internal class PrinterProcess
    {
        private string slicePath;
        private BeamerOutput beamerForm;
        private bool running = false;
        private Main mainForm;
        private PrinterConnector printerConnection;
        private List<Image> images;
        private List<Image> thumbnails;

        public PrinterProcess(string slicePath, BeamerOutput form, Main mainForm)
        {
            this.slicePath = slicePath;
            this.beamerForm = form;
            this.mainForm = mainForm;
            this.printerConnection = new PrinterConnector();
        }

        internal void Stop()
        {
            this.running = false;
        }

        internal void Start()
        {
            this.running = true;
            if (this.printerConnection.Connected || 
                this.printerConnection.Connect()
            ) {
                this.printerConnection.Write("START");
                new Thread(Run) { IsBackground = true }.Start();
            } else {
                this.mainForm.StatusMessage("Failed to connect to server.");
                this.running = false;
                this.mainForm.Done();
            }
        }

        private void Run()
        {
            try {
                // TODO: loads all images into memory, impractical for very large models
                this.mainForm.StatusMessage("Loading images from " + this.slicePath);
                this.images = LoadImages();
                this.thumbnails = GenerateThumbs(this.images);
                this.mainForm.StatusMessage("Loading complete");
                ProjectAllImages();
                SignalDone();
                this.running = false;
                this.mainForm.Done();
            } finally {
                this.printerConnection.Disconnect();
            }
        }

        private List<Image> LoadImages()
        {
            var list = new List<Image>();
            var imageTypes = new string[] { ".bmp", ".png", ".jpg" };
            var files = Directory
                .GetFiles(this.slicePath)
                .Where(fileName =>
                    imageTypes.Contains(Path.GetExtension(fileName).ToLower())
                )
                .OrderBy(fileName => fileName);
            foreach (var imageFile in files) {
                list.Add(Image.FromFile(imageFile));
            }
            return list;
        }

        private List<Image> GenerateThumbs(List<Image> images)
        {
            var list = new List<Image>();
            foreach (var image in images) {
                list.Add(
                    image.GetThumbnailImage(204, 144, () => { return false; }, IntPtr.Zero)
                );
            }
            return list;
        }

        private void ProjectAllImages()
        {
            var count = images.Count;
            this.mainForm.SetTotalSlices(count);
            var percentageDone = 0;
            for (int i = 0; i < count; i++) {
                this.mainForm.SetCurrentSlice(i);
                WaitForClient();
                if (!this.running) {
                    break;
                }
                Project(images[i], thumbnails[i]);
                SignalLayerDone();
                percentageDone = UpdatePercentageDone(count, percentageDone, i);
            }
        }

        private void WaitForClient()
        {
            Thread.Sleep(100); // Make sure printer has time to update status after last command
            while (this.Pause && this.running) {
                Thread.Sleep(250);
            }
            while (this.running && !this.printerConnection.Connected) {
                this.mainForm.StatusMessage("Client not connected... pausing");
                if (this.printerConnection.Connect()) {
                    this.mainForm.StatusMessage("Client re-connected");
                    break;
                } else {
                    Thread.Sleep(500);
                }
            }
            while (this.running && !this.printerConnection.PrinterReady) {
                this.mainForm.StatusMessage("Printer not ready, waiting.");
            }
        }

        private void Project(Image image, Image thumb)
        {
            this.mainForm.SetThumbnail(thumb);
            this.beamerForm.SetImage(image);
            Thread.Sleep(1000);
            this.beamerForm.SetImage(null);
        }

        private void SignalLayerDone()
        {
            this.printerConnection.Write("PULSE");
        }

        private int UpdatePercentageDone(int totalCount, int currentPercentageDone, int processedIndex)
        {
            var curPercent = (int)Math.Ceiling(((processedIndex + 1) / (decimal)totalCount) * 100);
            if (curPercent > currentPercentageDone) {
                currentPercentageDone = curPercent;
                this.mainForm.SetProgress(currentPercentageDone);
            }
            return currentPercentageDone;
        }

        private void SignalDone()
        {
            this.printerConnection.Write("DONE");
        }

        public bool Pause { get; set; }
    }
}
