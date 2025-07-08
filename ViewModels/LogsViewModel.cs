using CommunityToolkit.Mvvm.ComponentModel;
using Repaso3.Services;
using System.Collections.ObjectModel;

namespace PinedaLEvaluacion3P.ViewModels;

public partial class LogsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> logs;

    public LogsViewModel()
    {
        Logs = new ObservableCollection<string>();
        CargarLogs();
    }

    private async void CargarLogs()
    {
        var registros = await LogService.LeerLogsAsync();
        Logs.Clear();
        foreach (var log in registros)
        {
            Logs.Add(log);
        }
    }
}