using System;
using System.Collections.Generic;

using AMLIDS.lib.common.Models;
using AMLIDS.Mobile.Services;

using Android.App.Usage;
using Android.Content;
using Android.Net;

namespace AMLIDS.Mobile.Droid.Services
{
    public class AndroidNetworkService : INetworkService
    {
        private readonly NetworkStatsManager _networkStatsManager;

        public AndroidNetworkService()
        {
            _networkStatsManager = (NetworkStatsManager)Android.App.Application.Context.GetSystemService(Context.NetworkStatsService);
        }

        public List<RawNetworkCaptureItem> GetNetworkData()
        {
            var bucket = _networkStatsManager.QuerySummaryForDevice(ConnectivityType.Mobile, "", 0, 1000);

            return new List<RawNetworkCaptureItem>();
        }
    }
}