using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller
{
    internal class PrinterConnector
    {
        private TcpClient connection;

        public bool Connected
        {
            get
            {
                return this.connection == null ? false : this.connection.Connected;
            }
        }

        public bool PrinterReady
        {
            get
            {
                if (this.Connected) {
                    byte[] response = new byte[256];
                    if (this.connection.Available > 0) {
                        this.connection.Client.Receive(response);
                        response = new byte[256];
                    }
                    this.Write("GET_READY_STATUS");
                    try {
                        if (this.connection.Client.Receive(response) == -1) {
                            return false;
                        }
                    } catch (SocketException) {
                        return false;
                    }
                    var message = Encoding.ASCII.GetString(response);
                    int i = message.IndexOf('\0');
                    if (i >= 0) message = message.Substring(0, i);
                    if (message.Trim().ToLower() == "ready") {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            }
        }

        public bool Connect()
        {
            if (this.connection != null) {
                throw new Exception("Already connected");
            }
            try {
                this.connection = new TcpClient("localhost", 5473);
                this.connection.ReceiveTimeout = 200;
                byte[] response = new byte[256];
                try {
                    this.connection.Client.Receive(response);
                } catch (SocketException) { }
                return true;
            } catch (SocketException) {
                return false;
            }
        }

        public void Disconnect()
        {
            if (this.connection != null) {
                this.connection.Close();
                this.connection = null;
            }
        }

        internal void Write(string message)
        {
            if (this.Connected) {
                try {
                    var data = Encoding.ASCII.GetBytes(message + "\0");
                    this.connection.Client.Send(data, data.Length, SocketFlags.None);
                    Thread.Sleep(100); // Need to wait for server to receive a bit longer (found during debugging profilab)
                } catch (Exception) {
                    this.connection = null;
                }
            }
        }
    }
}
