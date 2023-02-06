using PreEntrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.ADO.NET
{
    public static class ProductosHandler
    {
        //La conexion a la base de datos
        public static string ConnectionString = "Data Source=LAPTOP-OH2KCBPB;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //lista de los productos
        public static List<Producto> ListaProductos()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("select * from Producto", conn);
                List<Producto> productos = new List<Producto>();
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoTemporal = new Producto();
                        productoTemporal.id = reader.GetInt64(0);
                        productoTemporal.descripcion = reader.GetString(1);
                        productoTemporal.costo = reader.GetDecimal(2);
                        productoTemporal.precioVenta = reader.GetDecimal(3);
                        productoTemporal.stock = reader.GetInt32(4);
                        productoTemporal.idUsuario = reader.GetInt64(5);

                        productos.Add(productoTemporal);

                    }
                }

                return productos;


            }
        }

        //obtener los productos con id
        public static Producto ObtenerProducto(long id)
        {
            Producto producto = new Producto();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Id =@id", connection);

                comando.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto.id = reader.GetInt64(0);
                    producto.descripcion = reader.GetString(1);
                    producto.costo = reader.GetDecimal(2);
                    producto.precioVenta = reader.GetDecimal(3);
                    producto.stock = reader.GetInt32(4);
                    producto.idUsuario = reader.GetInt64(5);

                }
            }
            return producto;
        }

        //traer los productos con el idusuario 
        public static List<Producto> TraerProducto(long idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<long> ListadeProducto = new List<long>();

                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario=@idUsuario", connection);


                //Tercera opción
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        ListadeProducto.Add(reader.GetInt64(0));

                    }

                }
                //Se va al metodo obtenedor productos para obtener el id de los productos que compro el ususario 
                List<Producto> producto = new List<Producto>();
                foreach (var id in ListadeProducto)
                {

                    Producto producTemporal = ObtenerProducto(id);
                    producto.Add(producTemporal);

                }

                return producto;
            }

        }

        //Obtener productos vendidos con id del usuario
        public static List<Producto> ObtenerProductoVendidos(long idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<long> ListadeProducto = new List<long>();

                SqlCommand comando2 = new SqlCommand("SELECT IdProducto FROM ProductoVendido" +
                    " INNER JOIN Producto" +
                    " ON ProductoVendido.IdProducto = Producto.Id" +
                    " WHERE IdUsuario = @idUsuario"
                    , connection);


                //Tercera opción
                comando2.Parameters.AddWithValue("@idUsuario", idUsuario);

                connection.Open();

                SqlDataReader reader = comando2.ExecuteReader();

                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        ListadeProducto.Add(reader.GetInt64(0));

                    }

                }
                //Se va al metodo obtenedor productos para obtener el id de los productos que compro el ususario 
                List<Producto> producto = new List<Producto>();
                foreach (var id in ListadeProducto)
                {

                    Producto producTemporal = ObtenerProducto(id);
                    producto.Add(producTemporal);

                }

                return producto;
            }
        }
    }
}
