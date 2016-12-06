// Used picture http://www.computerhope.com/jargon/p/packet.jpg
using System;
using System.Text;
using SharpPcap;

namespace SnifferWSharpPcap
{
    static class Program
    {
        public static int BytesToInt(byte b1, byte b2)
        {
            int fst = (int)b1;
            fst <<= 8;
            return fst + b2;
        }

        public static int GetBitFromByte(byte srcByte, int numOfBit)
        {
            return (srcByte >> (7 - numOfBit)) & 1;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static string ByteArrayToString(byte[] byteArray)
        {
            StringBuilder hex = new StringBuilder(byteArray.Length * 2);
            foreach (byte b in byteArray)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        static void Main(string[] args)
        {
            //Extract the device list
            CaptureDeviceList devices = CaptureDeviceList.Instance;
            if (devices.Count < 1)
            {
                Console.WriteLine("Couldn't find any device");
                return;
            }
            Console.WriteLine("The following devices are available on this machine:\n");
            for (var i = 0; i < devices.Count; i++)
            {
                Console.WriteLine("[{0}] - {1}", i, devices[i].ToString());
            }

            Console.WriteLine();
            Console.Write("Please choose a device to capture: ");
            var devIndex = int.Parse(Console.ReadLine());

            var device = devices[devIndex];
            device.Open(DeviceMode.Promiscuous);

            string filter = "ip and tcp";
            device.Filter = filter;

            device.OnPacketArrival += new PacketArrivalEventHandler(deviceOnPacketArrival);

            device.StartCapture();
            Console.WriteLine("Please press enter to exit...");
            Console.ReadKey();
        }


        private static void deviceOnPacketArrival(object sender, CaptureEventArgs e)
        {
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var tcpPacket = PacketDotNet.TcpPacket.GetEncapsulated(packet);
            if (tcpPacket != null)
            {
                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                int srcPort = tcpPacket.SourcePort;
                int dstPort = tcpPacket.DestinationPort;
                Console.WriteLine("********************************************************************************");
                Console.WriteLine("IP: ");
                Console.WriteLine("Version: {0}", ipPacket.Bytes[0] >> 4);
                Console.WriteLine("Length: {0}", ipPacket.Bytes[0] << 4);
                Console.WriteLine("Type of service: {0}", ipPacket.Bytes[1]);
                Console.WriteLine("Total length: {0}", BytesToInt(ipPacket.Bytes[2], ipPacket.Bytes[3]));
                Console.WriteLine("Identification: {0}", ipPacket.Bytes[4] + ipPacket.Bytes[5]);
                byte byteWithFlags = ipPacket.Bytes[6];
                Console.WriteLine("Flags: {0}{1}{2}", GetBitFromByte(byteWithFlags, 0), GetBitFromByte(byteWithFlags, 1), GetBitFromByte(byteWithFlags, 2));
                Console.WriteLine("Fragment offset: {0}", BytesToInt((byte)(byteWithFlags & 31) , ipPacket.Bytes[7]));
                Console.WriteLine("Time to Live: {0}", ipPacket.Bytes[8]);
                Console.WriteLine("Protocol: {0}", ipPacket.Bytes[9]);
                Console.WriteLine("Header checksum: {0}", ByteArrayToString(SubArray(ipPacket.Bytes, 10, 2)));
                Console.WriteLine("Source IP: {0}.{1}.{2}.{3}", ipPacket.Bytes[12], ipPacket.Bytes[13], ipPacket.Bytes[14], ipPacket.Bytes[15]);
                Console.WriteLine("Destination IP: {0}.{1}.{2}.{3}", ipPacket.Bytes[16], ipPacket.Bytes[17], ipPacket.Bytes[18], ipPacket.Bytes[19]);
                Console.WriteLine(@"Options: " + Convert.ToString(ipPacket.Bytes[20], 2).PadLeft(8, '0') + Convert.ToString(ipPacket.Bytes[21], 2).PadLeft(8, '0') +
                    Convert.ToString(ipPacket.Bytes[22], 2).PadLeft(8, '0') + Convert.ToString(ipPacket.Bytes[23], 2).PadLeft(8, '0'));
                if (ipPacket.Bytes.Length > 24)
                {
                    Console.WriteLine("Data: " + ByteArrayToString(SubArray(ipPacket.Bytes, 24, ipPacket.Bytes.Length - 24)));
                }
                Console.WriteLine("TCP:");
                Console.WriteLine("Src port: " + BytesToInt(tcpPacket.Bytes[0], tcpPacket.Bytes[1]));
                Console.WriteLine("Destination port: " + BytesToInt(tcpPacket.Bytes[2], tcpPacket.Bytes[3]));
                Console.WriteLine(@"Sequence Number: {0}", ByteArrayToString(SubArray(tcpPacket.Bytes, 4, 4)));
                Console.WriteLine("Acknowledgement Number: {0}", ByteArrayToString(SubArray(tcpPacket.Bytes, 8, 4)));
                Console.WriteLine("Offset: {0}{1}{2}{3}", GetBitFromByte(tcpPacket.Bytes[12], 0), GetBitFromByte(tcpPacket.Bytes[12], 1), GetBitFromByte(tcpPacket.Bytes[12], 2), GetBitFromByte(tcpPacket.Bytes[12], 3));
                Console.WriteLine(@"Reserved: {0}{1}{2}{3}{4}{5}", GetBitFromByte(tcpPacket.Bytes[12], 4), GetBitFromByte(tcpPacket.Bytes[12], 5),
                    GetBitFromByte(tcpPacket.Bytes[12], 6), GetBitFromByte(tcpPacket.Bytes[12], 7), GetBitFromByte(tcpPacket.Bytes[13], 0), GetBitFromByte(tcpPacket.Bytes[13], 1));
                Console.WriteLine("TCP flags: {0}{1}{2}{3}{4}{5}", GetBitFromByte(tcpPacket.Bytes[13], 2), GetBitFromByte(tcpPacket.Bytes[13], 3), GetBitFromByte(tcpPacket.Bytes[13], 4),
                    GetBitFromByte(tcpPacket.Bytes[13], 5), GetBitFromByte(tcpPacket.Bytes[13], 6), GetBitFromByte(tcpPacket.Bytes[13], 7));
                Console.WriteLine("Window: {0}", BytesToInt(tcpPacket.Bytes[14], tcpPacket.Bytes[15]));
                Console.WriteLine("Checksum: {0}", BytesToInt(tcpPacket.Bytes[16], tcpPacket.Bytes[17]));
                Console.WriteLine("Urgent pointer: {0}", ByteArrayToString(SubArray(tcpPacket.Bytes, 18, 2)));
            }



        }
    }
}