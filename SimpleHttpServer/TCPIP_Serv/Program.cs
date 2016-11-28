using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("server.test");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 1488);

            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting for connection on port {0}", ipEndPoint);

                    Socket handler = sListener.Accept();
                    string data = null;
                    string error = "Something wrong happened";
                    byte[] errMsg = Encoding.UTF8.GetBytes(error);
                    
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    
                    string filename = Regex.Match(data, @"\/([A-Za-z0-9\-._~:?#\[\]@!$%&'()*+,;=]*)(.jpg|.bmp|.txt)").Value;
                    try
                    {
                        filename = filename.Substring(7);
                    }
                    catch { }
                    Console.Write(">>> Accepted request: " + data + "\n\n");
                    string fileDescription = "";
                    switch (filename)
                    {
                        case "test.txt":
                            {
                                fileDescription = "You wanna get " + filename + ". W8 pls\n";
                                byte[] byteFileDescription = Encoding.UTF8.GetBytes(fileDescription);
                                handler.Send(byteFileDescription);
                                handler.Send(File.ReadAllBytes("test.txt"));
                                break;
                            }
                        case "test.jpg":
                            {
                                fileDescription = "You wanns get " + filename + ". W8 pls\n";
                                byte[] byteFileDescription = Encoding.UTF8.GetBytes(fileDescription);
                                handler.Send(byteFileDescription);
                                handler.Send(File.ReadAllBytes("test.jpg"));
                                break;
                            }
                        default:
                            {
                                fileDescription = "File " + filename + " does not exist or empty file name";
                                byte[] byteFileDescription = Encoding.UTF8.GetBytes(fileDescription);
                                handler.Send(byteFileDescription);
                                break;
                            }
                    }
                                        
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}