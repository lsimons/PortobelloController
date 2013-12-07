﻿using System;
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
        private IPrinterInterface printerInterface;
        private List<string> images;
        private Dictionary<string, Image> imageBuffer;
        private int projectionTimeMs = 1000;
        private int projectionTimeMsFirstGroup = -1;
        private int projectionTimeMsFirstGroupCount = -1;
        private int projectionTimeMsSecondGroup = -1;
        private int projectionTimeMsSecondGroupCount = -1;

        private object bufferLock = new object();

        public bool Pause { get; set; }

        public PrinterProcess(string slicePath, BeamerOutput form, Main mainForm)
        {
            InitializePrinterProcess(slicePath, form, mainForm, new LabjackPrinterInterface());
        }

        public PrinterProcess(string slicePath, BeamerOutput form, Main mainForm, IPrinterInterface printerInterface)
        {
            InitializePrinterProcess(slicePath, form, mainForm, printerInterface);
        }

        private void InitializePrinterProcess(string slicePath, BeamerOutput form, Main mainForm, IPrinterInterface printerInterface)
        {
            this.slicePath = slicePath;
            this.beamerForm = form;
            this.mainForm = mainForm;
            this.printerInterface = printerInterface;
            this.imageBuffer = new Dictionary<string, Image>();
        }

        internal void Stop()
        {
            this.running = false;
        }

        internal void Start()
        {
            this.running = true;
            string error;
            if (this.printerInterface.Connected ||
                this.printerInterface.TryConnect(out error)
            ) {
                this.mainForm.StatusMessage("Printer connected");
                try {
                    new Thread(Run) { IsBackground = true }.Start();
                } catch (Exception err) {
                    this.mainForm.StatusMessage("Unknown error." + Environment.NewLine + err.ToString());
                    this.running = false;
                    this.mainForm.Done();
                }
            } else {
                this.mainForm.StatusMessage("Failed to connect to server: " + error);
                this.running = false;
                this.mainForm.Done();
            }
        }

        private void Run()
        {
            try {
                this.mainForm.StatusMessage("Loading images list " + this.slicePath);
                LoadImages();
                InitializePrinter();
                this.mainForm.StatusMessage("Loading complete");
                var bufferThread = new Thread(FillBufferThread);
                bufferThread.IsBackground = true;
                bufferThread.Start();
                ProjectAllImages();
                SignalDone();
                this.running = false;
                this.mainForm.Done();
            } catch (Exception err) {
                this.mainForm.StatusMessage("Unknown error." + Environment.NewLine + err.ToString());
                this.running = false;
                this.mainForm.Done();
            }
        }

        private void LoadImages()
        {
            var imageTypes = new string[] { ".bmp", ".png", ".jpg", ".jpeg", ".tif" };
            this.images = Directory.GetFiles(this.slicePath)
                .Where(fileName =>
                    imageTypes.Contains(Path.GetExtension(fileName).ToLower())
                )
                .OrderBy(fileName => fileName)
                .ToList();
        }

        private void InitializePrinter()
        {
            try {
                this.printerInterface.ResinPump = true;
                this.printerInterface.MoveLiftToTop();
                this.printerInterface.MoveLiftDown(7000);
                this.printerInterface.MoveLiftUp(500);
                Thread.Sleep(1000);
            } finally {
                this.printerInterface.ResinPump = false;
            }
        }

        private void FillBufferThread()
        {
            lock (imageBuffer) {
                imageBuffer = new Dictionary<string, Image>();
            }
            int lastImageLoaded = 0;
            while (this.running) {
                lock (imageBuffer) {
                    while (this.imageBuffer.Count < 10 && images.Count > lastImageLoaded) {
                        lastImageLoaded++;
                        var path = images[lastImageLoaded - 1];
                        imageBuffer[path] = GenerateImage(path);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void ProjectAllImages()
        {
            var count = images.Count;
            this.mainForm.SetTotalSlices(count);
            var percentageDone = 0;
            for (int i = 0; i < count; i++) {
                this.mainForm.SetCurrentSlice(i+1);
                if (!this.running) {
                    break;
                }
                this.mainForm.StatusMessage("Projecting image for layer " + i.ToString());
                Project(images[i]);
                MoveLift(i);
                percentageDone = UpdatePercentageDone(count, percentageDone, i);
                while (this.Pause) {
                    Thread.Sleep(200);
                }
            }
        }

        private void MoveLift(int layer)
        {
            if (this.printerInterface.BottomSensor) {
                throw new Exception("Maximum print size reached.");
            }
            if (this.projectionTimeMsFirstGroupCount > 0) {
                Thread.Sleep(1000);
            } else if (this.projectionTimeMsSecondGroupCount > 0) {
                this.printerInterface.MoveLiftDown(30);
            } else {
                this.printerInterface.MoveLiftDown(5000);
                this.printerInterface.MoveLiftUp(4930);
            }
            Thread.Sleep(200);
        }
        
        private void Project(string imagePath)
        {
            var image = GetImage(imagePath);
            this.mainForm.SetThumbnail(image);
            this.beamerForm.SetImage(image);
            if (this.projectionTimeMsFirstGroupCount > 0) {
                this.projectionTimeMsFirstGroupCount--;
                Thread.Sleep(this.projectionTimeMsFirstGroup);
            } else if (this.projectionTimeMsSecondGroupCount > 0) {
                this.projectionTimeMsSecondGroupCount--; 
                Thread.Sleep(this.projectionTimeMsSecondGroup);
            } else {
                Thread.Sleep(this.projectionTimeMs);
            }
            this.beamerForm.SetImage(null);
            RemoveFromBuffer(imagePath);
        }

        private Image GetImage(string imagePath)
        {
            lock (this.bufferLock) {
                if (!this.imageBuffer.ContainsKey(imagePath)) {
                    this.imageBuffer[imagePath] = GenerateImage(imagePath);
                }
                return this.imageBuffer[imagePath];
            }
        }

        private Image GenerateImage(string imagePath)
        {
            return Image.FromFile(imagePath);
        }

        private void RemoveFromBuffer(string imagePath)
        {
            lock (this.bufferLock) {
                this.imageBuffer.Remove(imagePath);
            }
        }

        private Image GenerateThumb(Image image)
        {
            return image.GetThumbnailImage(204, 144, () => { return false; }, IntPtr.Zero);
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
            if (this.running) {
                this.printerInterface.MoveLiftToTop();
                this.mainForm.StatusMessage("Lift in top position.");
            }
        }

        internal bool SetProjectionTime(int projectionTimeMs)
        {
            if (!this.running || this.Pause) {
                this.projectionTimeMs = projectionTimeMs;
                return true;
            } else {
                return false;
            }
        }

        internal bool SetProjectionTimeFirstGroup(int projectionTimeMs, int layerCount)
        {
            if (!this.running) {
                this.projectionTimeMsFirstGroup = projectionTimeMs;
                this.projectionTimeMsFirstGroupCount = layerCount;
                return true;
            } else {
                return false;
            }
        }

        internal bool SetProjectionTimeSecondGroup(int projectionTimeMs, int layerCount)
        {
            if (!this.running) {
                this.projectionTimeMsSecondGroup = projectionTimeMs;
                this.projectionTimeMsSecondGroupCount = layerCount;
                return true;
            } else {
                return false;
            }
        }
    }
}
