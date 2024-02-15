using MapsDAO.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsModels.Models;

namespace MapsSQLiteDaoImpl.Impl
{
    public class ZonasSQLiteDaoImpl : IZonasDAO
    {
        string cadenaConexion = "";

        public ZonasSQLiteDaoImpl(string path)
        {
            this.cadenaConexion = $"Data Source={path};Version=3; Pooling=true;";
            Inicializar();
        }

        public ZonasSQLiteDaoImpl() : this(Path.GetFullPath("db/maps.db"))
        {
            Inicializar();
        }

        private void Inicializar()
        {
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
CREATE TABLE IF NOT EXISTS zonas (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT NOT NULL
)";
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public Zona Agregar(Zona nuevo,int idCredencial)
        {
            return null;
        }

        public void Actualizar(Zona modulo)
        {
           
        }
        
        public void Eliminar(int id)
        {
            
        }

        public Zona BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet BuscarTodos()
        {
            DataSet ds = new DataSet();
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT id, descripcion, url, id_credencial
FROM modulos";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    using (var adapter = new SQLiteDataAdapter(query))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }

            return ds;
        }
    }
}
