using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesAgency.CapaDatos
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public Usuarios(string _usuario, string _password )
        {
            Usuario = _usuario;
            Password = _password;   
            
        }
        public Usuarios() { }

        public bool login(string usuario, string password)
        {
            string nombreUsuario = string.Empty;
            SqlConnection sqlConnection=new SqlConnection();
            sqlConnection = Conexion.GetConexion().crearConexion();
            string queryLogin = "select nombre from Usuarios where nombre=@nombre and [Password]=@password";
           SqlCommand cmd=new SqlCommand(queryLogin, sqlConnection);
            cmd.Parameters.AddWithValue("@nombre", usuario);
            cmd.Parameters.AddWithValue("@password", password);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombreUsuario = reader["nombre"].ToString();
            }
            reader.Close();
            if(nombreUsuario != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

   

    }
}
