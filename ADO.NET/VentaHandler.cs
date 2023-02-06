using PreEntrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.ADO.NET
{
    public static class VentaHandler
    {
        //La conexion a la base de datos
        public static string ConnectionString = "Data Source=LAPTOP-OH2KCBPB;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Venta ObtenerVenta(long id)
        {
            Venta venta = new Venta();

            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE Id = @id", conexion);
                comando.Parameters.AddWithValue("@id", id);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    venta.id = reader.GetInt64(0);
                    venta.comentario = reader.GetString(1);
                    venta.idUsuario = reader.GetInt64(2);
                }
            }
            return venta;
        }

        // Traer Ventas - recibe un id de usuario y devuelve lista ventas realizadas por ese usuario
        public static List<Venta> TraerVenta(long idUsuario)
        {
            List<long> ventaRealizada = new List<long>();
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT Id FROM Venta " +
                    " WHERE IdUsuario = @idUsuario", conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ventaRealizada.Add(reader.GetInt64(0));
                    }
                }
            }
            List<Venta> listaVentasRealizadas = new List<Venta>();
            foreach (var id in ventaRealizada)
            {
                Venta ventaTempporal = ObtenerVenta(id);
                listaVentasRealizadas.Add(ventaTempporal);
            }
            return listaVentasRealizadas;
        }

    }
}
