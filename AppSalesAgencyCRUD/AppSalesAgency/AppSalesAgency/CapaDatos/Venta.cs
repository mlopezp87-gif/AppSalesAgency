using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesAgency.CapaDatos
{
    public class Venta
    {
        public int IdCliente { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public int GuardarVenta()
        {
            int resultado = 0;

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string query = "INSERT INTO Venta VALUES(@fecha,@cliente,@descuento,@total)";

            SqlCommand cmd = new SqlCommand(query, conex);

            cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmd.Parameters.AddWithValue("@cliente", IdCliente);
            cmd.Parameters.AddWithValue("@descuento", Descuento);
            cmd.Parameters.AddWithValue("@total", Total);

            conex.Open();
            resultado = cmd.ExecuteNonQuery();
            conex.Close();

            return resultado;
        }
        public DataTable ListarVentas()
        {
            DataTable dt = new DataTable();

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string consulta = @"SELECT v.IdVenta,
                                v.Fecha,
                                c.Nombre,
                                v.Descuento,
                                v.Total
                                FROM Venta v
                                INNER JOIN Cliente c
                                ON v.IdCliente = c.IdCliente";

            SqlDataAdapter da = new SqlDataAdapter(consulta, conex);
            da.Fill(dt);

            return dt;
        }
    }
}
