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
                var images = LoadImages();
                var thumbnails = GenerateThumbs(images);
                this.mainForm.StatusMessage("Loading complete");
                for (int i = 0; i < images.Count; i++) {
                    WaitForClient();
                    if (!this.running) {
                        break;
                    }
                    Project(images[i], thumbnails[i]);
                    SignalLayerDone();
                }
                SignalDone();
                this.running = false;
                this.mainForm.Done();
            } finally {
                this.printerConnection.Disconnect();
            }
        }

        private void WaitForClient()
        {
            while (!this.printerConnection.Connected && this.running) {
                this.mainForm.StatusMessage("Client not connected... pausing");
                if (this.printerConnection.Connect()) {
                    this.mainForm.StatusMessage("Client re-connected");
                    break;
                } else {
                    Thread.Sleep(500);
                }
            }

            while (!this.printerConnection.PrinterReady && this.running) {
                this.mainForm.StatusMessage("Printer not ready, waiting.");
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

        private void SignalDone()
        {
            this.printerConnection.Write("DONE");
        }
    }
}
