using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public  SqlConnection conexion;
        private  string server = "Tarea2";//cambiar datos para el server
        private  string user = "sa";
        private  string password = "AdminAzure@12";
        private  string database = "Libreria";

        public  bool Connect()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;

                conexion = new SqlConnection();
                conexion.ConnectionString = $"Data Source={server};Initial Catalog={database};User ID={user};Password={password}";
                conexion.Open();

                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  void Disconnect()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Dispose();
                conexion.Close();
            }
        }
    }
}
