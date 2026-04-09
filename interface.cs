using System;
using System.Collections.Generic;

namespace TaskInter
{
    class NetworkPacket
    {
        public string SourceIP;
        public string Payload;

        public NetworkPacket(string sourceIP, string payload)
        {
            SourceIP = sourceIP;
            Payload = payload;
        }
    }

    interface IPacketFilter {bool Analyze(NetworkPacket packet);}

    class SqlInjectionFilter : IPacketFilter 
    {
        public bool Analyze(NetworkPacket packet)
        {
            string payload = packet.Payload;
            if (payload.ToUpper().Contains("SELECT") || payload.ToUpper().Contains("DROP"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class SpamFilter : IPacketFilter
    {
        public bool Analyze(NetworkPacket packet)
        {
            string payload = packet.Payload;
            if (payload.Length > 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class TrafficAnalyzer
    {
        public List<IPacketFilter> filters = new List<IPacketFilter>();
        public void ProcessQueue(Queue<NetworkPacket> packets)
        {
            while (packets.Count > 0)
            {
                NetworkPacket current = packets.Dequeue();
                bool isDangerous = false;
                foreach (var filter in filters)
                {
                    if (filter.Analyze(current) == false)
                    {
                        isDangerous = true;
                        break;
                    }
                }
                if (isDangerous)
                {
                    Console.WriteLine("DANGEROUS!");
                }
                else
                {
                    Console.WriteLine("CORRECT");
                }
            }
        }
    }
    public class TaskI
    {
        static void Main()
        {
            Queue<NetworkPacket> packet = new Queue<NetworkPacket>();
            packet.Enqueue(new NetworkPacket("192.168.1.1","Hello World"));
            packet.Enqueue(new NetworkPacket("10.0.0.2","SELECT * FROM users"));
            packet.Enqueue(new NetworkPacket("8.8.8.8","AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"));
            packet.Enqueue(new NetworkPacket("255.255.255.255","DROP user-asagi"));
            packet.Enqueue(new NetworkPacket("255.0.0.0","HI EVERYONE"));

            TrafficAnalyzer analyzer = new TrafficAnalyzer();

            SqlInjectionFilter filter1 = new SqlInjectionFilter();
            SpamFilter filter2 = new SpamFilter();

            analyzer.filters.Add(filter1);
            analyzer.filters.Add(filter2);

            analyzer.ProcessQueue(packet);
        }
    }
}