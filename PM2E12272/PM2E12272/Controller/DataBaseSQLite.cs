using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2E12272.Models;
using SQLite;

namespace PM2E12272.Controller
{
    public class DataBaseSQLite
    {

        readonly SQLiteAsyncConnection db;

        //Constructor de la clase DataBaseSQLite

        public DataBaseSQLite(String pathdb)
        {
            //Crear conexion a bd
            db = new SQLiteAsyncConnection(pathdb);

            //creacion de la tabla ubicacion dentro de SQLite
            db.CreateTableAsync<gps>().Wait();

        }

        //Operaciones CRUD con SQLite
        //READ List Way

        public Task<List<gps>> ObtenerListaGPS()
        {
            return db.Table<gps>().ToListAsync();
        }

        // READ one by one
        public Task<gps> ObtenerUbicacion(int pcodigo)
        {
            return db.Table<gps>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //CREATE 
        public Task<int> GrabarUbicacion(gps ubicacion)
        {
            if (ubicacion.codigo != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }

        //DELETE
        public Task<int> EliminarUbicacion(gps ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }
    }
}
