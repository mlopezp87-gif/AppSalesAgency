using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSalesAgency.CapaDatos
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }

        public int GuardarProducto()
        {
            int resultado = 0;

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string query = "INSERT INTO Producto VALUES(@nombre,@precio,@stock,@proveedor,@categoria)";

            SqlCommand cmd = new SqlCommand(query, conex);

            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@precio", Precio);
            cmd.Parameters.AddWithValue("@stock", Stock);
            cmd.Parameters.AddWithValue("@proveedor", IdProveedor);
            cmd.Parameters.AddWithValue("@categoria", IdCategoria);

            conex.Open();
            resultado = cmd.ExecuteNonQuery();
            conex.Close();

            return resultado;
        }

        public DataTable ListarProductos()
        {
            DataTable dt = new DataTable();

            SqlConnection conex = Conexion.GetConexion().crearConexion();

            string consulta = @"SELECT p.IdProducto,
                                p.Nombre,
                                p.Precio,
                                p.Stock,
                                pr.Nombre AS Proveedor,
                                c.Nombre AS Categoria
                                FROM Producto p
                                INNER JOIN Proveedor pr
                                ON p.IdProveedor = pr.IdProveedor
                                INNER JOIN Categoria c
                                ON p.IdCategoria = c.IdCategoria";

            SqlDataAdapter da = new SqlDataAdapter(consulta, conex);
            da.Fill(dt);

            return dt;
        }
    }
}
