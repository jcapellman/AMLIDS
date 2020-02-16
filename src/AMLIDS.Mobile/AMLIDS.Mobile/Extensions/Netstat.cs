using System;

using AMLIDS.Mobile.Models;

namespace AMLIDS.Mobile.Extensions
{
    public static class Netstat
    {
        public static Item ToItem(this string lineOutput)
        {
            var item = new Item();

            if (!lineOutput.StartsWith("tcp") && !lineOutput.StartsWith("udp"))
            {
                return null;
            }

            var data = lineOutput.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            } else
            {
                return null; // TODO: Handle IPv6
            }

            if (data[4].Split(':').Length == 2)
            {
                var destinationData = data[4].Split(':');

                item.DestinationIP = destinationData[0];
                item.DestinationPort = Convert.ToInt32(destinationData[1]);
            } else
            {
                return null; // TODO: Handle IPv6
            }

            item.State = data[5];

            return item;
        }
    }
}