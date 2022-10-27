using NicolasAlvarez.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Dominios
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int Idusuario { get; set; }
        ADO_Venta listaventa = new ADO_Venta();

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
            Idusuario = 0;
        }

        public List<Venta> TraerVenta(int idUsuario)
        {
            return listaventa.TraerVenta(idUsuario);
        }
    }

}
