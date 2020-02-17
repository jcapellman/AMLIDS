using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Xamarin.Forms;

using AMLIDS.Mobile.Models;
using AMLIDS.Mobile.Extensions;
using AMLIDS.lib.dal;

namespace AMLIDS.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Traffic";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
        }

        private List<Item> GetConnections()
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

            var items = new List<Item>();

            while (!process.StandardOutput.EndOfStream)
            {
                var item = process.StandardOutput.ReadLine().ToItem();

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

                DependencyService.Get<IDataStorage>().InsertBulkNetworkData(items);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
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