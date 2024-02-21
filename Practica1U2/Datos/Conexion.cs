using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        // Declaración de una variable estática para la conexión a la base de datos.
        public static MySqlConnection conexion;

        // Método estático para establecer una conexión a la base de datos.
        public static bool Conectar()
        {
            try
            {
                // Verifica si ya hay una conexión abierta.
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                    return true;

                // Si no hay una conexión abierta, crea una nueva y la abre.
                conexion = new MySqlConnection();
                conexion.ConnectionString = "server=172.214.73.62;uid=UsuarioAdmin;pwd=UsuarioAdmin@12;database=Practica1";
                conexion.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                // Captura excepciones específicas de MySQL y devuelve "false" en caso de error.
                return false;
            }
            catch (Exception e)
            {
                // Captura excepciones generales y devuelve "false" en caso de error
                return false;
            }
        }

        // Método estático para cerrar la conexión a la base de datos.
        public static void Desconectar()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
