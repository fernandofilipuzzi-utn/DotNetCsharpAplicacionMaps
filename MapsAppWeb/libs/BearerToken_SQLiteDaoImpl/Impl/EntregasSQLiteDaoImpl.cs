using MapsDAO.DAO;
using MapsModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsSQLiteDaoImpl.Impl
{
    public class EntregasSQLiteDaoImpl : IEntregasDAO
    {
        string cadenaConexion = "";

        public EntregasSQLiteDaoImpl(string path)
        {
            cadenaConexion = $"Data Source={path};Version=3; Pooling=true;";
            Inicializar();
        }

        public EntregasSQLiteDaoImpl() : this(Path.GetFullPath("db/maps.db"))
        {
        }

        private void Inicializar()
        {
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
CREATE TABLE IF NOT EXISTS entregas (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    id_pedido INTEGER,
    id_zona INTEGER,
    id_repartido INTEGER,
    fecha_hora_disponible DATETIME
);";
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

        public Entrega Agregar(Entrega nueva)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
INSERT INTO entregas (id_pedido, id_zona, id_repartido, fecha_hora_disponible)
VALUES (@IdPedido, @IdZona, @IdRepartido, @FechaHoraDisponible)
RETURNING id;";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("IdPedido", DbType.Int64));
                    query.Parameters.Add(new SQLiteParameter("IdZona", DbType.Int64));
                    query.Parameters.Add(new SQLiteParameter("IdRepartido", DbType.Int64));
                    query.Parameters.Add(new SQLiteParameter("FechaHoraDisponible", SqlDbType.DateTime));
                    //
                    query.Parameters["IdPedido"].Value = nueva.IdPedido;
                    query.Parameters["IdZona"].Value = nueva.IdZona;
                    query.Parameters["IdRepartido"].Value = nueva.IdRepartido;
                    query.Parameters["FechaHoraDisponible"].Value = nueva.FechaHoraDisponible;
                    //
                    object id = query.ExecuteScalar();
                    nueva.Id = Convert.ToInt32(id);
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
            return nueva;
        }

        public void Actualizar(Entrega entrega)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
    UPDATE entregas SET guid=@Guid, clave=@Clave, habilitado=@Habilitado, scopes=@Scopes
    WHERE id=@Id" ;

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("IdPedido", DbType.Int64));
                    query.Parameters.Add(new SQLiteParameter("IdZona", DbType.Int64));
                    query.Parameters.Add(new SQLiteParameter("IdRepartido", DbType.Int64));
                    query.Parameters.Add(new SQLiteParameter("FechaHoraDisponible", SqlDbType.DateTime));
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int64));
                    //
                    query.Parameters["IdPedido"].Value = entrega.IdPedido;
                    query.Parameters["IdZona"].Value = entrega.IdZona;
                    query.Parameters["IdRepartido"].Value = entrega.IdRepartido;
                    query.Parameters["FechaHoraDisponible"].Value = entrega.FechaHoraDisponible;
                    query.Parameters["Id"].Value = entrega.Id;
                    //
                    query.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                //System.Data.SQLite.SQLiteException: 'SQL logic error near ")": syntax error'
                //System.Data.SQLite.SQLiteException: 'database is locked database is locked'
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public void Eliminar(int id)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
DELETE FROM entregas
WHERE id = @Id;";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int32));
                    //
                    query.Parameters["Id"].Value = id;
                    //
                    int rows = query.ExecuteNonQuery();
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

        public Entrega BuscarPorId(int idBuscado)
        {
            Entrega buscado = null;

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT id_pedido, id_zona, id_repartido, fecha_hora_disponible
FROM entregas
WHERE id=@Id;";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int32));
                    query.Parameters["Id"].Value = idBuscado;
                    //
                    SQLiteDataReader dataReader = query.ExecuteReader();

                    if (dataReader.Read())
                    {
                        #region id_pedido
                        int idPedido = 0;
                        if (dataReader["id_pedido"] != DBNull.Value)
                            idPedido = Convert.ToInt32(dataReader["id_pedido"]);
                        #endregion

                        #region clave
                        string clave = "";
                        if (dataReader["clave"] != DBNull.Value)
                            clave = Convert.ToString(dataReader["clave"]);
                        #endregion

                        #region descripcion
                        string descripcion = "";
                        if (dataReader["descripcion"] != DBNull.Value)
                            descripcion = Convert.ToString(dataReader["descripcion"]);
                        #endregion

                        #region habilitado
                        bool habilitado = false;
                        if (dataReader["habilitado"] != DBNull.Value)
                            habilitado = Convert.ToBoolean(dataReader["habilitado"]);
                        #endregion

                        #region scopes
                        string scopes = "";
                        if (dataReader["scopes"] != DBNull.Value)
                            scopes = Convert.ToString(dataReader["scopes"]);
                        #endregion

                        buscado = new Entrega 
                        { 
                            Id = idBuscado, 
                            IdPedido = idPedido, 
                        };
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
            return buscado;
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
SELECT id, id_pedido, id_zona, id_repartido, fecha_hora_disponible
FROM entregas;";

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
