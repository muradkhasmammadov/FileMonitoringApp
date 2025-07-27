using System.Collections.ObjectModel;
using XalqBankTestAppFileMonitoring.Models;
using XalqBankTestAppFileMonitoring.Services;

namespace XalqBankTestApp
{
    public class MainViewModel
    {
        public ObservableCollection<FileData> FileData { get; } = new();
        private readonly FileMonitorService monitor;

        public MainViewModel()
        {
            monitor = new FileMonitorService();
            monitor.OnDataLoaded += filedata =>
            {
                App.Current.Dispatcher.Invoke(() => FileData.Add(filedata));
            };
            monitor.Start();
        }
    }
}
