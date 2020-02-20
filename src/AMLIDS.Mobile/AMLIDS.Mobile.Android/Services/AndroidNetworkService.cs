using System;
using System.Collections.Generic;

using AMLIDS.lib.common.Models;
using AMLIDS.Mobile.Services;

using Android.App;
using Android.App.Usage;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Telephony;

namespace AMLIDS.Mobile.Droid.Services
{
    public class AndroidNetworkService : INetworkService
    {
        private readonly NetworkStatsManager _networkStatsManager;

        private readonly int _packageUid;

        public AndroidNetworkService()
        {
            _networkStatsManager =
                (NetworkStatsManager) Android.App.Application.Context.GetSystemService(Context.NetworkStatsService);

            _packageUid = Application.Context.PackageManager.GetPackageUid(Application.Context.PackageName,
                PackageInfoFlags.MatchAll);
        }

        public List<RawNetworkCaptureItem> GetNetworkData()
        {
            TelephonyManager tm = (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);

            var bucket = _networkStatsManager.QuerySummaryForDevice(ConnectivityType.Mobile, tm.SubscriberId, 0, 1000);

            return new List<RawNetworkCaptureItem>();
        }
    }
}