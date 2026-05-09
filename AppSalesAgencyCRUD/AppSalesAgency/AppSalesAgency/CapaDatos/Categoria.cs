using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesAgency.CapaDatos
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int GuardarCategoria()
        {
            int resultado = 0;

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string query = "INSERT INTO Categoria VALUES(@nombre,@descripcion)";

            SqlCommand cmd = new SqlCommand(query, conex);

            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@descripcion", Descripcion);

            conex.Open();
            resultado = cmd.ExecuteNonQuery();
            conex.Close();

            return resultado;
        }

        public DataTable ListarCategorias()
        {
            DataTable dt = new DataTable();

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string consulta = "SELECT * FROM Categoria";

            SqlDataAdapter da = new SqlDataAdapter(consulta, conex);
            da.Fill(dt);

            return dt;
        }
    }
}