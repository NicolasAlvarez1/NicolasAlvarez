using NicolasAlvarez.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Dominios
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Idproducto { get; set; }
        public int Stock { get; set; }
        public int Idventa { get; set; }
        ADO_ProductoVendido listaproductov = new ADO_ProductoVendido();

        public ProductoVendido()
        {
            Id = 0;
            Idproducto = 0;
            Stock = 0;
            Idventa = 0;
        }

        public List<ProductoVendido> TraerProductoVendido(int idUsuario)
        {
            return listaproductov.TraerProductoVendido(idUsuario);
        }

    }
}

