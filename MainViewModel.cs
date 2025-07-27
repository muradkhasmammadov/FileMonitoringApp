using System.Collections.ObjectModel;
using XalqBankTestApp;
using XalqBankTestAppFileMonitoring.Interfaces;
using XalqBankTestAppFileMonitoring.Models;
using XalqBankTestAppFileMonitoring.Services;

public class MainViewModel
{
    public ObservableCollection<FileData> FileData { get; } = new();
    private readonly FileMonitorService monitor;

    public MainViewModel()
    {
        var fileSystem = new FileSystem();
        var config = new AppConfigProvider();
        var pluginLoader = new PluginLoader(config);

        monitor = new FileMonitorService(fileSystem, config, pluginLoader);

        monitor.OnDataLoaded += filedata =>
        {
            App.Current.Dispatcher.Invoke(() => FileData.Add(filedata));
        };
        monitor.Start();
    }
}
