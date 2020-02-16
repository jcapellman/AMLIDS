using System;

namespace AMLIDS.Mobile.Models
{
    public class Item
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