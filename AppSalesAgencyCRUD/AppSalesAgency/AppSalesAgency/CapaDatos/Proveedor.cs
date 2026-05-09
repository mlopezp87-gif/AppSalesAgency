using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesAgency.CapaDatos
{
    public class Proveedor
    {

        public int ID { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string PaginaWeb { get; set; }

        public Proveedor()
        {
        }

        public Proveedor(string nit, string nombre, string direccion,
            string telefono, string paginaWeb)
        {
            Nit = nit;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            PaginaWeb = paginaWeb;
        }

        public int GuardarProveedor()
        {
            int resultado = 0;

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string query = "INSERT INTO Proveedor VALUES(@nit,@nombre,@direccion,@telefono,@paginaweb)";

            SqlCommand cmd = new SqlCommand(query, conex);

            cmd.Parameters.AddWithValue("@nit", Nit);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@direccion", Direccion);
            cmd.Parameters.AddWithValue("@telefono", Telefono);
            cmd.Parameters.AddWithValue("@paginaweb", PaginaWeb);

            conex.Open();
            resultado = cmd.ExecuteNonQuery();
            conex.Close();

            return resultado;
        }

        public DataTable ListarProveedor()
        {
            DataTable dt = new DataTable();

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string consulta = "SELECT * FROM Proveedor";

            SqlDataAdapter da = new SqlDataAdapter(consulta, conex);
            da.Fill(dt);

            return dt;
        }


        public int ActualizarProveedor()
        {
            int resultado = 0;

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string query = "UPDATE Proveedor SET Nit=@nit, Nombre=@nombre, Direccion=@direccion, Telefono=@telefono, PaginaWeb=@paginaweb WHERE IdProveedor=@id";

            SqlCommand cmd = new SqlCommand(query, conex);

            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@nit", Nit);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@direccion", Direccion);
            cmd.Parameters.AddWithValue("@telefono", Telefono);
            cmd.Parameters.AddWithValue("@paginaweb", PaginaWeb);

            conex.Open();
            resultado = cmd.ExecuteNonQuery();
            conex.Close();

            return resultado;
        }

        public int EliminarProveedor(int id)
        {
            int resultado = 0;

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string query = "DELETE FROM Proveedor WHERE IdProveedor=@id";

            SqlCommand cmd = new SqlCommand(query, conex);
            cmd.Parameters.AddWithValue("@id", id);

            conex.Open();
            resultado = cmd.ExecuteNonQuery();
            conex.Close();

            return resultado;
        }

    }
}
