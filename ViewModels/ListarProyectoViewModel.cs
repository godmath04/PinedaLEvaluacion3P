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
        try
        {
            var lista = await App.Database.ObtenerProyectoAsync();

            if (lista == null)
            {
                Console.WriteLine("La lista de proyectos es NULL");
                return;
            }

            Console.WriteLine($"Se encontraron {lista.Count} proyectos");

            Proyectos.Clear();
            foreach (var proyecto in lista)
            {
                Proyectos.Add(proyecto);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error cargando proyectos: " + ex.Message);
        }
    }

}
