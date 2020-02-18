using System.Collections.Generic;

using AMLIDS.lib.common.Models;

namespace AMLIDS.Mobile.Services
{
    public interface INetworkService
    {
        List<RawNetworkCaptureItem> GetNetworkData();
    }
}