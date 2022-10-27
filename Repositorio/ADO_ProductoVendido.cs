using NicolasAlvarez.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Repositorio
{
    public class ADO_ProductoVendido
    {
        public List<ProductoVendido> TraerProductoVendido(int idUsuario)
        {
            var Listaproductosvendidos = new List<ProductoVendido>();

            string cadena = "Server=NICOLAS; Database=SistemaGestion; Trusted_Connection=true;";
            int idproductov = 0;

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();
                var producto = new Producto();
                List<Producto> listaproducto = producto.TraerProducto(idUsuario);
                foreach (Producto v in listaproducto)
                {
                    idproductov = v.Id;
                    comando.CommandText = "SELECT pv.Id,pv.Idproducto,pv.Stock,pv.Idventa " +
                    "FROM ProductoVendido pv " +
                    "INNER JOIN Venta v on(pv.Idventa = v.Id) " +
                    "WHERE v.IdUsuario = @varidusuario AND pv.Idproducto = @varidproducto";

                    var parametrou = new SqlParameter();
                    parametrou.ParameterName = "varidusuario";
                    parametrou.Value = idUsuario;
                    comando.Parameters.Add(parametrou);

                    var parametrop = new SqlParameter();
                    parametrop.ParameterName = "varidproducto";
                    parametrop.Value = idproductov;
                    comando.Parameters.Add(parametrop);

                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        var productov = new ProductoVendido();
                        productov.Id = Convert.ToInt32(reader.GetValue(0));
                        productov.Idproducto = Convert.ToInt32(reader.GetValue(1));
                        productov.Stock = Convert.ToInt32(reader.GetValue(2));
                        productov.Idventa = Convert.ToInt32(reader.GetValue(3));
                        Listaproductosvendidos.Add(productov);
                    }
                    reader.Close();
                    comando.Parameters.Clear();

                }
                connection.Close();
            }
            return Listaproductosvendidos;
        }

    }
}
