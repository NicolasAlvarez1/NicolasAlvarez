using NicolasAlvarez.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasAlvarez.Handlers
{
    public class ADO_Producto
    {
        public List<Producto> TraerProducto(int idUsuario)
        {
            var Listaproductos = new List<Producto>();

            string cadena = "Server=NICOLAS; Database=SistemaGestion; Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT * from Producto WHERE IdUsuario = @varidusuario";
                var parametro = new SqlParameter();
                parametro.ParameterName = "varidusuario";
                parametro.Value = idUsuario;
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
