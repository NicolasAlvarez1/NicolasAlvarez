using NicolasAlvarez.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precioventa { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        ADO_Producto listaproductosAdo = new ADO_Producto();

        public Producto()
        {
            Id = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precioventa = 0;
            Stock = 0;
            IdUsuario = 0;
        }

        public List<Producto> TraerProducto(int idUsuario)
        {
            return listaproductosAdo.TraerProducto(idUsuario);
        }
    }
}
