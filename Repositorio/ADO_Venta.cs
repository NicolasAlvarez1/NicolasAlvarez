using NicolasAlvarez.Dominios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Repositorio
{
    public class ADO_Venta
    {
        public List<Venta> TraerVenta(int idUsuario)
        {
            var Listaventa = new List<Venta>();

            string cadena = "Server=NICOLAS; Database=SistemaGestion; Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT pv.Id,pv.Idproducto,pv.Stock,v.Comentarios,pr.Descripciones,pr.PrecioVenta " +
                    "FROM ProductoVendido pv " +
                    "INNER JOIN Venta v on(pv.Idventa = v.Id) " +
                    "INNER JOIN Producto pr on(pr.Id=pv.Idproducto) " +
                    "WHERE v.IdUsuario = @varidusuario";

                var parametrou = new SqlParameter();
                parametrou.ParameterName = "varidusuario";
                parametrou.Value = idUsuario;
                comando.Parameters.Add(parametrou);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var productov = new Venta();
                    productov.Id = Convert.ToInt32(reader.GetValue(0));
                    productov.Comentarios = reader.GetValue(3).ToString();

                    Listaventa.Add(productov);
                }
                connection.Close();
            }
            return Listaventa;
        }
    }
}
