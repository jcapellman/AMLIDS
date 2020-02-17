using System;

namespace AMLIDS.lib.dal.Models
{
    public class NetworkDataItem
    {
        public int Version { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string JSON { get; set; }
    }
}