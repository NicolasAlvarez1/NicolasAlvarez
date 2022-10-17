using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precioventa { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
            this.Id = 0;
            this.Descripcion = string.Empty;
            this.Costo = 0;
            this.Precioventa = 0;
            this.Stock = 0;
            this.IdUsuario = 0;
        }

        public List<Producto> TraerProducto(int Pidusuario)
        {
            int Vidusuario = Pidusuario;
            var Listaproductos = new List<Producto>();

            string cadena = "Server=NICOLAS; Database=SistemaGestion; Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT * from Producto WHERE IdUsuario = @varidusuario";
                var parametro = new SqlParameter();
                parametro.ParameterName = "varidusuario";
                parametro.Value = Vidusuario;
                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var producto = new Producto();
                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripcion = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToDouble(reader.GetValue(2));
                    producto.Precioventa = Convert.ToDouble(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));

                    Listaproductos.Add(producto);
                }
                connection.Close();
            }
            return Listaproductos;
        }
    }
}
