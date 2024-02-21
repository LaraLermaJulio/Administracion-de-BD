using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    public class AreasDAO
    {
        public List<Areas> GetAreas()
        {
            List<Areas> lista = new List<Areas>();

            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand("SELECT * FROM AREAS", Conexion.conexion);

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = sentencia;
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow fila in dt.Rows)
                    {
                        Areas area = new Areas
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            Nombre = fila["Nombre"].ToString(),
                            Ubicacion = fila["Ubicacion"].ToString()
                        };
                        lista.Add(area);
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

        public bool InsertArea(string nombre, string ubicacion)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand("INSERT INTO AREAS (Nombre, Ubicacion) VALUES (@nombre, @ubicacion)", Conexion.conexion);
                    sentencia.Parameters.AddWithValue("@nombre", nombre);
                    sentencia.Parameters.AddWithValue("@ubicacion", ubicacion);

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

        public bool UpdateArea(int id, string nombre, string ubicacion)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand("UPDATE AREAS SET Nombre = @nombre, Ubicacion = @ubicacion WHERE Id = @id", Conexion.conexion);
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Parameters.AddWithValue("@nombre", nombre);
                    sentencia.Parameters.AddWithValue("@ubicacion", ubicacion);

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

        public bool DeleteArea(int id)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    MySqlCommand sentencia = new MySqlCommand("DELETE FROM AREAS WHERE Id = @id", Conexion.conexion);
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


