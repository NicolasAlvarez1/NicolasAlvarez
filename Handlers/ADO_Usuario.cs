using NicolasAlvarez.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Handlers
{
    public class ADO_Usuario
    {
        string cadena = "Server=NICOLAS; Database=SistemaGestion; Trusted_Connection=true;";
        Usuario pusuario = new Usuario();

        public Usuario TraerUsuario(string nombre)
        {
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT * from Usuario WHERE Nombre LIKE @varnombre";
                var parametro = new SqlParameter();
                parametro.ParameterName = "varnombre";
                parametro.Value = nombre;
                comando.Parameters.Add(parametro);
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    pusuario.Id = Convert.ToInt32(reader.GetValue(0));
                    pusuario.Nombre = reader.GetValue(1).ToString();
                    pusuario.Apellido = reader.GetValue(2).ToString();
                    pusuario.NombreUsuario = reader.GetValue(3).ToString();
                    pusuario.Contraseña = reader.GetValue(4).ToString();
                    pusuario.Mail = reader.GetValue(5).ToString();
                }
                connection.Close();
            }
            return pusuario;
        }

        public Usuario Logueo(string nombreUsuario, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT * from Usuario WHERE NombreUsuario=@varnombreusuario AND Contraseña=@varcontraseña";
                var parametro = new SqlParameter();
                parametro.ParameterName = "varnombreusuario";
                parametro.Value = nombreUsuario;
                comando.Parameters.Add(parametro);

                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "varcontraseña";
                parametro2.Value = contraseña;
                comando.Parameters.Add(parametro2);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader.GetValue(0)) != 0)
                    {
                        pusuario.Id = Convert.ToInt32(reader.GetValue(0));
                        pusuario.Nombre = reader.GetValue(1).ToString();
                        pusuario.Apellido = reader.GetValue(2).ToString();
                        pusuario.NombreUsuario = reader.GetValue(3).ToString();
                        pusuario.Contraseña = reader.GetValue(4).ToString();
                        pusuario.Mail = reader.GetValue(5).ToString();
                    }
                }
                connection.Close();
            }
            return pusuario;
        }

    }
}
