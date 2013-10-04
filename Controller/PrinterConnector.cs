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
                    try {
                        this.connection.Client.Receive(response);
                        response = new byte[256];
                    } catch (SocketException) {
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
                    
                    if (message.ToLower().Contains("ready")) {
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
                this.connection.ReceiveTimeout = 3000;
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
                    var data = Encoding.ASCII.GetBytes(message);
                    this.connection.Client.Send(data, data.Length, SocketFlags.None);
                } catch (Exception) {
                    this.connection = null;
                }
            }
        }
    }
}
