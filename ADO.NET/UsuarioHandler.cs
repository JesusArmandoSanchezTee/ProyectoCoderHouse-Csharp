using PreEntrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PreEntrega.ADO.NET
{
    public static class UsuarioHandler
    {
        //La conexion a la base de datos
        public static string ConnectionString = "Data Source=LAPTOP-OH2KCBPB;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Obtener la lista de los usuarios
        public static List<Usuario> ListaUsuarios()
        {
            List<Usuario> usuario = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", connection);

                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuarioTemporal = new Usuario();
                        usuarioTemporal.id = reader.GetInt64(0);
                        usuarioTemporal.nombre = reader.GetString(1);
                        usuarioTemporal.apellido = reader.GetString(2);
                        usuarioTemporal.nombreUsuario = reader.GetString(3);
                        usuarioTemporal.contrasena = reader.GetString(4);
                        usuarioTemporal.mail = reader.GetString(5);


                        usuario.Add(usuarioTemporal);
                    }
                }
                return usuario;


            }
        }

        // Obtener a un usuario con el id
        public static Usuario ObtenerUsuario(long id)
        { 
            Usuario usuario = new Usuario();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Id=@id", connection);

                comando.Parameters.AddWithValue("@Id", id);
                connection.Open();


                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.id = reader.GetInt64(0);
                    usuario.nombre = reader.GetString(1);
                    usuario.apellido = reader.GetString(2);
                    usuario.nombreUsuario = reader.GetString(3);
                    usuario.contrasena = reader.GetString(4);
                    usuario.mail = reader.GetString(5);

                }
                

            }
            return usuario;
        }


        //Iniciar seción con su nombre de usuario y contraseña
        public static Usuario IniciarSecion(string nombreUsuario, string contrasena)
        {

            Usuario usuario = new Usuario();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario=@nombreUsuariO AND Contraseña=@contrasena", connection);
                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);
                connection.Open();


                SqlDataReader reader = comando.ExecuteReader();
                if(reader.HasRows)
                {

                    reader.Read();
                    usuario.id = reader.GetInt64(0);
                    usuario.nombre = reader.GetString(1);
                    usuario.apellido = reader.GetString(2);
                    usuario.nombreUsuario = reader.GetString(3);
                    usuario.contrasena = reader.GetString(4);
                    usuario.mail = reader.GetString(5);

                }
                else
                {
                    usuario.id = 0;
                    Console.WriteLine("Usuario y/o Contraseña Incorrectos");
                }

            }
            return usuario;

        }
        

        



    }
}
