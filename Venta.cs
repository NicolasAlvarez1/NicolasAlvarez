using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int Idusuario { get; set; }
        public ProductoVendido produven { get; set; }
 
        public Venta()
        {
            this.Id=0;
            this.Comentarios=string.Empty;
            this.Idusuario=0;
            this.produven = new ProductoVendido();
        }

        public List<Venta> TraerVenta(int Pidusuario)
        {
            int Vidusuario = Pidusuario;
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
                parametrou.Value = Vidusuario;
                comando.Parameters.Add(parametrou);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var productov = new Venta();
                    productov.Id = Convert.ToInt32(reader.GetValue(0));
                    productov.produven.Idproducto = Convert.ToInt32(reader.GetValue(1));
                    productov.produven.Stock = Convert.ToInt32(reader.GetValue(2));
                    productov.Comentarios = reader.GetValue(3).ToString();
                    productov.produven.productop.Descripcion = reader.GetValue(4).ToString();
                    productov.produven.productop.Precioventa = Convert.ToDouble(reader.GetValue(5));

                    Listaventa.Add(productov);
                }
                connection.Close();
            }
            return Listaventa;
        }
    }

}
