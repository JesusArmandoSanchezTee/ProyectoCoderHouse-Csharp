using PreEntrega.ADO.NET;
using PreEntrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PreEntrega;

namespace PreEntrega
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //iniciar secion con el nombre y contraseña
            //Usuario usuario = UsuarioHandler.IniciarSecion("tcasazza", "SoyTobiasCasazza");
            //Console.WriteLine(usuario.nombre);

            // Traer Usuario - recibe id usuario
            //Usuario usuario = UsuarioHandler.ObtenerUsuario(1);
            //Console.WriteLine(usuario.nombre);

            // Traer Productos Vendidos - recibe un id de usuario y devuelve una lista de productos vendidos por ese usuario 
            //List<Producto> productos = ProductosHandler.ObtenerProductoVendidos(1);
            //foreach (var item in productos)
            //{
            //    Console.WriteLine(item.descripcion);
            //}


            //Productos Vendidos
            //List<ProductoVendido> productos = ProductoVendidoHandler.TraerProductosVendidos(1);
            //foreach (var item in productos)
            //{
            //    Console.WriteLine(item.idProducto);
            //}




            //Productos del usuario
            //List<Producto> productos = ProductosHandler.TraerProducto(1);
            //foreach (var item in productos)
            //{
            //    Console.WriteLine(item.descripcion);
            //}



            //Traer Venta
            //List<Venta> listProducto = VentaHandler.TraerVenta(1);
            //foreach (var item in listProducto)
            //{
            //    Console.WriteLine(item.id);
            //}






        }
    }
}
