//Usar atributos y crear comandos
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PinedaLEvaluacion3P.Models;
//using PinedaLEvaluacion3P.Services;
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

        
        public void GuardarProyecto()
        {

            //Logica del limite que no se puede ingresar mayor al 50% y duracion de <1año
            if (progreso > 50 && duracionDias < 365)
            {
                App.Current.MainPage.DisplayAlert("Error", "No se puede garuardar un proyecto con progreso mayor al 50% y menor a un año", "OK");

                return;

            }

            //Si los datos son validos
            App.Current.MainPage.DisplayAlert("Correcto", "Proyecto guardado correctamente en la base de datos", "OK");




        }

    }
}
