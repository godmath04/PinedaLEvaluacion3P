using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinedaLEvaluacion3P.Models;
using SQLite;

namespace PinedaLEvaluacion3P.Services
{
    public class ProyectoService
    {
        private readonly SQLiteAsyncConnection _db;

        public ProyectoService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<Proyecto>().Wait();
        }


        //Metodo publico apra insertar proyecto en la vista
        public Task<int> InsertarProyectoAsync(Proyecto proyecto)
        {
            return _db.InsertAsync(proyecto);
        }

        //Leer los registros de la tabla Proyecto,
        public Task<List<Proyecto>> ObtenerProyectoAsync()
        {
            return _db.Table<Proyecto>().ToListAsync();
        }
    }
}
