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
        private List<string> images;
        private int projectionTimeMs = 1000;

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
                try {
                    new Thread(Run) { IsBackground = true }.Start();
                } catch (Exception err) {
                    this.mainForm.StatusMessage("Unknown error." + Environment.NewLine + err.ToString());
                    this.running = false;
                    this.mainForm.Done();
                }
            } else {
                this.mainForm.StatusMessage("Failed to connect to server.");
                this.running = false;
                this.mainForm.Done();
            }
        }

        private void Run()
        {
            try {
                this.mainForm.StatusMessage("Loading images list " + this.slicePath);
                this.images = LoadImages();
                this.mainForm.StatusMessage("Loading complete");
                ProjectAllImages();
                SignalDone();
                this.running = false;
                this.mainForm.Done();
            } catch (Exception err) {
                this.mainForm.StatusMessage("Unknown error." + Environment.NewLine + err.ToString());
                this.running = false;
                this.mainForm.Done();
            } finally {
                this.printerConnection.Disconnect();
            }
        }

        private List<string> LoadImages()
        {
            var list = new List<string>();
            var imageTypes = new string[] { ".bmp", ".png", ".jpg", ".jpeg", ".tif" };
            var files = Directory
                .GetFiles(this.slicePath)
                .Where(fileName =>
                    imageTypes.Contains(Path.GetExtension(fileName).ToLower())
                )
                .OrderBy(fileName => fileName);
            foreach (var imageFile in files) {
                list.Add(imageFile);
            }
            return list;
        }

        private void ProjectAllImages()
        {
            var count = images.Count;
            this.mainForm.SetTotalSlices(count);
            var percentageDone = 0;
            for (int i = 0; i < count; i++) {
                WaitForClient();
                this.mainForm.SetCurrentSlice(i+1);
                if (!this.running) {
                    break;
                }
                Project(images[i]);
                SignalLayerDone();
                percentageDone = UpdatePercentageDone(count, percentageDone, i);
            }
        }

        private void WaitForClient()
        {
            Thread.Sleep(50); // Make sure printer has time to update status after last command
            while (this.Pause && this.running) {
                Thread.Sleep(250);
            }
            while (this.running && !this.printerConnection.Connected) {
                this.mainForm.StatusMessage("Client not connected... pausing");
                if (this.printerConnection.Connect()) {
                    this.mainForm.StatusMessage("Client re-connected");
                    break;
                } else {
                    Thread.Sleep(200);
                }
            }
            int notReadyCount = 0;
            while (this.running && !this.printerConnection.PrinterReady) {
                notReadyCount++;
                if ((notReadyCount = notReadyCount % 10) == 0) {
                    this.mainForm.StatusMessage("Printer not ready, waiting.");
                }
                Thread.Sleep(100);
            }
        }

        private void Project(string imagePath)
        {
            var image = GenerateImage(imagePath);
            this.mainForm.SetThumbnail(image);
            this.beamerForm.SetImage(image);
            Thread.Sleep(projectionTimeMs);
            this.beamerForm.SetImage(null);
        }


        private Image GenerateImage(string imagePath)
        {
            return Image.FromFile(imagePath);
        }

        private Image GenerateThumb(Image image)
        {
            return image.GetThumbnailImage(204, 144, () => { return false; }, IntPtr.Zero);
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
            this.printerConnection.Write("STOP");
        }

        public bool Pause { get; set; }

        internal bool SetProjectionTime(int projectionTimeMs)
        {
            if (!this.running || this.Pause) {
                this.projectionTimeMs = projectionTimeMs;
                return true;
            } else {
                return false;
            }
        }
    }
}
