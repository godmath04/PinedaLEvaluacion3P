using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PinedaLEvaluacion3P;
using PinedaLEvaluacion3P.Models;
using PinedaLEvaluacion3P.Services;

namespace PinedaLEvaluacion3P.ViewModels;

public partial class ListarProyectoViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Proyecto> proyectos;

    public ICommand CargarProyectosCommand { get; }

    public ListarProyectoViewModel()
    {
        proyectos = new ObservableCollection<Proyecto>();
        CargarProyectosCommand = new RelayCommand(async () => await CargarProyectos());
        CargarProyectosCommand.Execute(null); // Se carga automáticamente
    }

    private async Task CargarProyectos()
    {
        var lista = await App.Database.ObtenerProyectoAsync();
        proyectos.Clear();
        foreach (var proyecto in lista)
        {
            proyectos.Add(proyecto);
        }
    }
}
