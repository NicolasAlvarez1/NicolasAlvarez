using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Idproducto { get; set; }
        public int Stock { get; set; }
        public int Idventa { get; set; }

        public ProductoVendido()
        {
            Id = 0;
            Idproducto = 0;
            Stock = 0;
            Idventa = 0;
        }
    }
}

