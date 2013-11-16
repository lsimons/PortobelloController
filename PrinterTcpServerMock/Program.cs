using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using sockets = System.Net.Sockets;

namespace PrinterTcpServerMock
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime lastPulse = DateTime.Now;
            var listener = new sockets.TcpListener(IPAddress.Loopback, 5473);
            listener.Start();
            try {
                while (true) {
                    Console.WriteLine("Listening for connection on port: 5473");
                    var client = listener.AcceptTcpClient();
                    Console.WriteLine("Client connected");
                    var buffer = new byte[1024];
                    var stream = client.GetStream();
                    int receivedByteCount = 0;
                    try {
                        while ((receivedByteCount = stream.Read(buffer, 0, buffer.Length)) != 0) {
                            var message = Encoding.ASCII.GetString(buffer, 0, receivedByteCount);
                            Console.Write(message + Environment.NewLine);
                            if (message.Contains("GET_READY_STATUS")) {
                                if (lastPulse < DateTime.Now.AddSeconds(-2)) {
                                    Thread.Sleep(100);
                                    Console.WriteLine("Sending: READY");
                                    client.Client.Send(
                                        Encoding.ASCII.GetBytes("READY")
                                    );
                                } else {
                                    Console.WriteLine("Sending: BUSY");
                                    client.Client.Send(
                                        Encoding.ASCII.GetBytes("BUSY")
                                    );
                                }
                            }
                            if (message.Contains("PULSE")) {
                                Console.WriteLine("Simulating printer moving (2 seconds)");
                                lastPulse = DateTime.Now;
                            }
                        }
                    } catch (System.IO.IOException err) {
                        Console.WriteLine(err.Message);
                    } finally {
                        client.Close();
                    }
                }
            } finally {
                listener.Stop();
            }
        }
    }
}
