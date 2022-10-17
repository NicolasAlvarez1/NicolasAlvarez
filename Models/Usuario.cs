using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;
using NicolasAlvarez.Handlers;

namespace NicolasAlvarez.Models
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

        public void TraerUsuario(string nombre)
        {

            Usuario usuarioADO = new Usuario();
            usuarioADO = pusuario.TraerUsuario(nombre);

            this.Id = usuarioADO.Id;
            this.Nombre = usuarioADO.Nombre;
            this.Apellido = usuarioADO.Apellido;
            this.NombreUsuario  =  usuarioADO.NombreUsuario;
            this.Contraseña = usuarioADO.Contraseña;
            this.Mail = usuarioADO.Mail;
        }

        public void Logueo(string nombreUsuario, string contraseña)
        {
            Usuario usuarioADO = new Usuario();
            usuarioADO = pusuario.Logueo(nombreUsuario,contraseña);
            this.Id = usuarioADO.Id;
            this.Nombre = usuarioADO.Nombre;
            this.Apellido = usuarioADO.Apellido;
            this.NombreUsuario = usuarioADO.NombreUsuario;
            this.Contraseña = usuarioADO.Contraseña;
            this.Mail = usuarioADO.Mail;
        }
    }
}
