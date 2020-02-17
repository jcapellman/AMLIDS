using System;

namespace AMLIDS.lib.common.Models
{
    public class RawNetworkCaptureItem
    {
        public DateTime TimeStamp { get; set; }

        public string Protocol { get; set; }

        public string SourceIP { get; set; }

        public int SourcePort { get; set; }

        public string DestinationIP { get; set; }

        public int DestinationPort { get; set; }

        public string State { get; set; }
    }
}