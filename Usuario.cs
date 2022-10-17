using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace NicolasAlvarez
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido  { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        private string cadena = "Server=NICOLAS; Database=SistemaGestion; Trusted_Connection=true;";

        public Usuario()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.NombreUsuario = string.Empty;
            this.Contraseña = string.Empty;
            this.Mail = string.Empty;
        }

        public void TraerUsuario(string Pnombre)
        {
            string Vnombre = Pnombre;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();
 
                comando.CommandText = "SELECT * from Usuario WHERE Nombre LIKE @varnombre";
                var parametro = new SqlParameter();
                parametro.ParameterName = "varnombre";
                parametro.Value = Vnombre;
                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    this.Id = Convert.ToInt32(reader.GetValue(0));
                    this.Nombre = reader.GetValue(1).ToString();
                    this.Apellido = reader.GetValue(2).ToString();
                    this.NombreUsuario = reader.GetValue(3).ToString();
                    this.Contraseña = reader.GetValue(4).ToString();
                    this.Mail = reader.GetValue(5).ToString();
                }
                connection.Close();
            }
        }

        public Usuario logueo(string Pnombreusuario, string Pcontraseña)
        {
            string Vnombreusuario = Pnombreusuario;
            string Vcontraseña = Pcontraseña;
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT * from Usuario WHERE NombreUsuario=@varnombreusuario AND Contraseña=@varcontraseña";
                var parametro = new SqlParameter();
                parametro.ParameterName = "varnombreusuario";
                parametro.Value = Vnombreusuario;
                comando.Parameters.Add(parametro);

                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "varcontraseña";
                parametro2.Value = Vcontraseña;
                comando.Parameters.Add(parametro2);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader.GetValue(0)) != 0)
                    {
                        this.Id = Convert.ToInt32(reader.GetValue(0));
                        this.Nombre = reader.GetValue(1).ToString();
                        this.Apellido = reader.GetValue(2).ToString();
                        this.NombreUsuario = reader.GetValue(3).ToString();
                        this.Contraseña = reader.GetValue(4).ToString();
                        this.Mail = reader.GetValue(5).ToString();
                    }
                }
                connection.Close();
            }
            return this;
        }
    }
}
