using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso3.Services
{
    public static class LogService
    {
        private static readonly string apellido = "Pineda";

        //Definimos la ruta del archivo donde se escriben los logs
        private static readonly string logPath = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData), $"Logs_{apellido}.txt");

        //Metodo asincrono que agrega linea al archivo de logs
        public static async Task EscribirLogAsync(string nombreProyecto)
        {
            string linea = $"Se incluye el registro [{nombreProyecto}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            //Se anade una nueva linea al final
            await File.AppendAllTextAsync(logPath, linea, Encoding.UTF8);

        }

        //Metodo asincrono para leer los logs recuperando las lienas y mostrandolas

        public static async Task<List<string>> LeerLogsAsync()
        {
            if (!File.Exists(logPath))
                return new List<string>();

            var lineas = await File.ReadAllLinesAsync(logPath);
            return lineas.ToList();
        }


    }
}
