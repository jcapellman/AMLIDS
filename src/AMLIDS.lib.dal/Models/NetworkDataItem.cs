using Newtonsoft.Json;

using System;

namespace AMLIDS.lib.dal.Models
{
    public class NetworkDataItem
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string JSON { get; set; }

        public NetworkDataItem() { }

        public NetworkDataItem(object payload, int dataDefinitionVersion)
        {
            Version = dataDefinitionVersion;

            JSON = JsonConvert.SerializeObject(payload);

            Timestamp = DateTimeOffset.Now;
        }
    }
}