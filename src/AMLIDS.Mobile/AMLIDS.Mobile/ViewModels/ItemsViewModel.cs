using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;

using AMLIDS.lib.dal;
using AMLIDS.lib.common.Models;
using AMLIDS.lib.common.Extensions;

namespace AMLIDS.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ObservableCollection<RawNetworkCaptureItem> _items;

        public ObservableCollection<RawNetworkCaptureItem> Items
        {
            get => _items;
            
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Traffic";
            Items = new ObservableCollection<RawNetworkCaptureItem>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
        }

        private List<RawNetworkCaptureItem> GetConnections()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/system/bin/netstat",
                    Arguments = "-n",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();

            var items = new List<RawNetworkCaptureItem>();

            while (!process.StandardOutput.EndOfStream)
            {
                var item = process.StandardOutput.ReadLine().ToRawNetworkCaptureItem();

                if (item == null)
                {
                    continue;
                }

                items.Add(item);
            }

            process.WaitForExit();

            return items;
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                var items = GetConnections();

                DependencyService.Get<IDataStorage>().InsertBulkNetworkData(items, lib.common.Common.Constants.DATA_DEFINITION_VERSION);

                foreach (var item in items)
                {
                    Items.Add(item);
                }

                Items = new ObservableCollection<RawNetworkCaptureItem>(Items.OrderByDescending(a => a.TimeStamp));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}