using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LibroDAO
    {
        Conexion conexion = new Conexion();

        public List<Libro> getAll()
        {
            List<Libro> libros = new List<Libro>();

            if (conexion.Connect())
            {
                try
                {
                    string query = "SELECT * FROM Libros";

                    DataTable dt = new DataTable();

                    SqlCommand command = new SqlCommand(query, conexion.conexion);
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Libro libro = new Libro(
                            id: Convert.ToInt32(row["ID"]),
                            isbn: row["ISBN"].ToString(),
                            titulo: row["Titulo"].ToString(),
                            numeroEdicion: Convert.ToInt32(row["Numero_Edicion"]),
                            anioPublicacion: Convert.ToInt32(row["Anio_Publicacion"]),
                            autores: row["Autores"].ToString(),
                            paisPublicacion: row["Pais_Publicacion"].ToString(),
                            sinopsis: row["Sinopsis"].ToString(),
                            carrera: row["Carrera"].ToString(),
                            materia: row["Materia"].ToString()
                        );
                        libros.Add(libro);
                    }

                    return libros;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
                finally
                {
                    conexion.Disconnect();
                }
            }
            else
            {
                return null;
            }
        }


        public bool AgregarLibro(Libro libro)
        {
            if (conexion.Connect())
            {
                try
                {
                    string query = @"INSERT INTO Libros (ISBN, Titulo, Numero_Edicion, Anio_Publicacion, Autores, Pais_Publicacion, Sinopsis, Carrera, Materia) 
                             VALUES (@ISBN, @Titulo, @Numero_Edicion, @Anio_Publicacion, @Autores, @Pais_Publicacion, @Sinopsis, @Carrera, @Materia)";

                    SqlCommand command = new SqlCommand(query, conexion.conexion);
                    command.Parameters.AddWithValue("@ISBN", libro.ISBN);
                    command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    command.Parameters.AddWithValue("@Numero_Edicion", libro.Numero_Edicion);
                    command.Parameters.AddWithValue("@Anio_Publicacion", libro.Anio_Publicacion);
                    command.Parameters.AddWithValue("@Autores", libro.Autores);
                    command.Parameters.AddWithValue("@Pais_Publicacion", libro.Pais_Publicacion);
                    command.Parameters.AddWithValue("@Sinopsis", libro.Sinopsis);
                    command.Parameters.AddWithValue("@Carrera", libro.Carrera);
                    command.Parameters.AddWithValue("@Materia", libro.Materia);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar libro: " + ex.Message);
                    return false;
                }
                finally
                {
                    conexion.Disconnect();
                }
            }
            else
            {
                return false;
            }
        }

    }
}
