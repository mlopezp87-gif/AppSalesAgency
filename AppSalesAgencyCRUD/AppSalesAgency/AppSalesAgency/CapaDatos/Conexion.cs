using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesAgency.CapaDatos
{
    public class Conexion
    {
        private string BaseDeDatos;
        private string Servidor;

        private static Conexion con = null;
        private Conexion()
        {
            this.BaseDeDatos = "AppSalesAgency";
            this.Servidor = "DESKTOP-5AKM4TR";

        }

        //metodo para gener la cadena de conexion



        public SqlConnection crearConexion()
        {
            SqlConnection cadConex = new SqlConnection();
            cadConex.ConnectionString="Server="+this.Servidor+
                "; Database="+this.BaseDeDatos+
                "; integrated security=SSPI";

            return cadConex;
        }

        public static Conexion GetConexion()
        {
            if (con == null)
            {
                con=new Conexion();
            }
            return con;
        
        }



    }
}
