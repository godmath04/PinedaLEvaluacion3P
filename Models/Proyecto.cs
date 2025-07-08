using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinedaLEvaluacion3P.Models
{
    public class Proyecto
    {
        //Creacion del modelo de registro de proyecto
        [PrimaryKey, AutoIncrement]
        private int Id { get; set; }

        private string NombreProyecto { get; set; }

        private string Responsable { get; set; }
        private decimal Progreso { get; set; }
        private int DuracionDias { get; set; }




    }
}
