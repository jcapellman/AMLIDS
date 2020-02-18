using System.Collections.Generic;

using AMLIDS.lib.common.Models;

namespace AMLIDS.lib.common.WebServiceObjects
{
    public class SubmissionRequestItem
    {
        public DeviceInformationItem DeviceInformation { get; set; }

        public List<RawNetworkCaptureItem> RawNetworkCaptureItems { get; set; }
    }
}