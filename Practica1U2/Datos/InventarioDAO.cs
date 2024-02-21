using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    public class InventarioDAO
    {
        public List<Inventario> GetInventario()
        {
            List<Inventario> lista = new List<Inventario>();

            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand("SELECT i.*, a.Nombre AS AreaNombre FROM Inventario i INNER JOIN AREAS a ON i.Areas_id = a.Id", Conexion.conexion);

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = sentencia;
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        Inventario inventario = new Inventario
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            NombreCorto = fila["NombreCorto"].ToString(),
                            Descripcion = fila["Descripcion"].ToString(),
                            Serie = fila["Serie"].ToString(),
                            Color = fila["Color"].ToString(),
                            FechaAdquision = Convert.ToDateTime(fila["FechaAdquision"]),
                            TipoAdquision = fila["TipoAdquision"].ToString(),
                            Observaciones = fila["Observaciones"].ToString(),
                            Areas_id = Convert.ToInt32(fila["Areas_id"]),
                            Area = fila["AreaNombre"].ToString()
                        };
                        lista.Add(inventario);
                    }
                    return lista;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }
        }

        public bool InsertElementInventario(string nombreCorto, string descripcion, string serie, string color, DateTime fechaAdquisicion, string tipoAdquisicion, string observaciones, int areasId)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand(
                        "INSERT INTO Inventario (NombreCorto, Descripcion, Serie, Color, FechaAdquision, TipoAdquision, Observaciones, Areas_id) " +
                        "VALUES (@nombreCorto, @descripcion, @serie, @color, @fechaAdquisicion, @tipoAdquisicion, @observaciones, @areasId)", Conexion.conexion);
                    sentencia.Parameters.AddWithValue("@nombreCorto", nombreCorto);
                    sentencia.Parameters.AddWithValue("@descripcion", descripcion);
                    sentencia.Parameters.AddWithValue("@serie", serie);
                    sentencia.Parameters.AddWithValue("@color", color);
                    sentencia.Parameters.AddWithValue("@fechaAdquisicion", fechaAdquisicion.ToString("yyyy-MM-dd"));
                    sentencia.Parameters.AddWithValue("@tipoAdquisicion", tipoAdquisicion);
                    sentencia.Parameters.AddWithValue("@observaciones", observaciones);
                    sentencia.Parameters.AddWithValue("@areasId", areasId);

                    sentencia.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateElementInventario(int id, string nombreCorto, string descripcion, string serie, string color, DateTime fechaAdquisicion, string tipoAdquisicion, string observaciones, int areasId)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand(
                        "UPDATE Inventario SET NombreCorto = @nombreCorto, Descripcion = @descripcion, Serie = @serie, Color = @color, " +
                        "FechaAdquision = @fechaAdquisicion, TipoAdquision = @tipoAdquisicion, Observaciones = @observaciones, Areas_id = @areasId " +
                        "WHERE Id = @id", Conexion.conexion);
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Parameters.AddWithValue("@nombreCorto", nombreCorto);
                    sentencia.Parameters.AddWithValue("@descripcion", descripcion);
                    sentencia.Parameters.AddWithValue("@serie", serie);
                    sentencia.Parameters.AddWithValue("@color", color);
                    sentencia.Parameters.AddWithValue("@fechaAdquisicion", fechaAdquisicion.ToString("yyyy-MM-dd"));
                    sentencia.Parameters.AddWithValue("@tipoAdquisicion", tipoAdquisicion);
                    sentencia.Parameters.AddWithValue("@observaciones", observaciones);
                    sentencia.Parameters.AddWithValue("@areasId", areasId);

                    sentencia.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteElementInventario(int id)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand("DELETE FROM Inventario WHERE Id = @id", Conexion.conexion);
                    sentencia.Parameters.AddWithValue("@id", id);

                    sentencia.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return false;
            }
        }
    }
}
