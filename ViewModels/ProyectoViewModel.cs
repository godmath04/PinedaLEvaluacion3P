//Usar atributos y crear comandos
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using PinedaLEvaluacion3P.Models;
using PinedaLEvaluacion3P.Services;
using Repaso3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PinedaLEvaluacion3P.ViewModels
{
    public partial class ProyectoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nombreProyecto;

        [ObservableProperty]
        private string responsable;

       

        [ObservableProperty]
        private decimal progreso;

        [ObservableProperty]
        private int duracionDias;


        //Command de la vista
        public ICommand SaveCommand { get;
        }

        public ProyectoViewModel(){
            SaveCommand = new RelayCommand(GuardarProyecto);

        }

        
        public async void GuardarProyecto()
        {

            //Logica del limite que no se puede ingresar mayor al 50% y duracion de <1año
            if (progreso > 50 && duracionDias < 365)
            {
                App.Current.MainPage.DisplayAlert("Error", "No se puede garuardar un proyecto con progreso mayor al 50% y menor a un año", "OK");

                return;

            }

            //Si los datos son validos
            //Instanciamos la clase proyecto y le pasamos los datos del formulario

            var nuevoProyecto = new Proyecto
            {
                NombreProyecto = NombreProyecto,
                Responsable = Responsable,
                Progreso = Progreso,
                DuracionDias = DuracionDias
            };
            //Guardar el prouecto mediante SQLite

            await App.Database.InsertarProyectoAsync(nuevoProyecto);

            await App.Current.MainPage.DisplayAlert("Éxito",
                "Proyecto guardado en la base de datos correctamente.",
                "OK");

            //Registro en log 
            await LogService.EscribirLogAsync(NombreProyecto);

            // Borramos campos
            NombreProyecto = string.Empty;
            Responsable = string.Empty;
            Progreso = 0;
            DuracionDias = 0;



        }

    }
}
