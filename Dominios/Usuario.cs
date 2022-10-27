using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using NicolasAlvarez.Repositorio;

namespace NicolasAlvarez.Dominios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }
        ADO_Usuario pusuario = new ADO_Usuario();

        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            Mail = string.Empty;

        }

        public Usuario TraerUsuario(string nombre)
        {
            return pusuario.TraerUsuario(nombre);
        }

        public Usuario Logueo(string nombreUsuario, string contraseña)
        {
            return pusuario.Logueo(nombreUsuario, contraseña);
        }
    }
}
