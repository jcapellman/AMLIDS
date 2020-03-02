using System;
using System.Collections.Generic;

using AMLIDS.lib.common.Models;
using AMLIDS.Mobile.Services;

using Java.IO;
using Java.Lang;

namespace AMLIDS.Mobile.Droid.Services
{
    public class AndroidNetworkService : INetworkService
    {
        private RawNetworkCaptureItem ParseNetStatLine(string line)
        {
            var item = new RawNetworkCaptureItem();

            if (!line.StartsWith("tcp") && !line.StartsWith("udp"))
            {
                return null;
            }

            var data = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (data.Length != 6)
            {
                return null;
            }

            item.TimeStamp = DateTime.Now;
            item.Protocol = data[0];

            if (data[3].Split(':').Length == 2)
            {
                var sourceData = data[3].Split(':');

                item.SourceIP = sourceData[0];
                item.SourcePort = Convert.ToInt32(sourceData[1]);
            }
            else
            {
                return null; // TODO: Handle IPv6
            }

            if (data[4].Split(':').Length == 2)
            {
                var destinationData = data[4].Split(':');

                item.DestinationIP = destinationData[0];
                item.DestinationPort = Convert.ToInt32(destinationData[1]);
            }
            else
            {
                return null; // TODO: Handle IPv6
            }

            item.State = data[5];

            return item;
        }
    
        public List<RawNetworkCaptureItem> GetNetworkData()
        {
            var p = Runtime.GetRuntime().Exec("netstat -n");

            var a = new BufferedReader(new InputStreamReader(p.InputStream));

            var lines = new List<RawNetworkCaptureItem>();

            string line = null;

            while ((line = a.ReadLine()) != null)
            {
                var item = ParseNetStatLine(line);

                if (item == null)
                {
                    continue;
                }

                lines.Add(item);
            }

            return lines;
        }
    }
}