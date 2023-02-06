using PreEntrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.ADO.NET
{
    public static class ProductoVendidoHandler
    {
        //La conexion a la base de datos
        public static string ConnectionString = "Data Source=LAPTOP-OH2KCBPB;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        //traer los productos vendidos
        public static List<ProductoVendido> TraerProductosVendidos(long idUsuario)
        {
            List<ProductoVendido> listProductosVendidos = new List<ProductoVendido>();
            List<Producto> listProductos = ProductosHandler.TraerProducto(idUsuario);

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {


                    foreach (Producto producto in listProductos)
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.Connection.Open();
                        sqlCommand.CommandText = @"SELECT * FROM ProductoVendido
                                                WHERE IdProducto = @idProducto";

                        sqlCommand.Parameters.AddWithValue("@idProducto", producto.id);


                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        dataAdapter.SelectCommand = sqlCommand;
                        DataTable table = new DataTable();
                        dataAdapter.Fill(table); //Se ejecuta el Select de la tabla productos vendidos
                        sqlCommand.Parameters.Clear();

                        foreach (DataRow row in table.Rows)
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.id = Convert.ToInt32(row["Id"]);
                            productoVendido.stock = Convert.ToInt32(row["Stock"]);
                            productoVendido.idProducto = Convert.ToInt32(row["IdProducto"]);
                            productoVendido.idVenta = Convert.ToInt32(row["IdVenta"]);

                            listProductosVendidos.Add(productoVendido);
                        }
                        sqlCommand.Connection.Close();
                    }

                }
            }
            return listProductosVendidos;
        }

    }
}
