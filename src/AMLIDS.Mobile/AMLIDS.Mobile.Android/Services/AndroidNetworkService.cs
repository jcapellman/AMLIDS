using System;
using System.Collections.Generic;

using AMLIDS.lib.common.Models;
using AMLIDS.Mobile.Services;

using Android.App;
using Android.App.Usage;
using Android.Content;
using Android.Net;
using Android.Telephony;

namespace AMLIDS.Mobile.Droid.Services
{
    public class AndroidNetworkService : INetworkService
    {
        class AppNetworkCallback : ConnectivityManager.NetworkCallback
        {
            public override void OnAvailable(Network network)
            {
                base.OnAvailable(network);
            }
        }

        private readonly NetworkStatsManager _networkStatsManager;

        private readonly int _packageUid;

        public AndroidNetworkService()
        {
            ConnectivityManager conn = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkRequest.Builder builder = new NetworkRequest.Builder();

            conn.RegisterNetworkCallback(builder.Build(), new AppNetworkCallback());
        }

        public List<RawNetworkCaptureItem> GetNetworkData()
        { 
       //     TelephonyManager tm = (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);

         //   var bucket = _networkStatsManager.QuerySummaryForDevice(ConnectivityType.Mobile, tm.SubscriberId, 0, 1000);

            //var log = System.IO.File.ReadAllLines("/proc/net/tcp");


            return new List<RawNetworkCaptureItem>();
        }
    }
}