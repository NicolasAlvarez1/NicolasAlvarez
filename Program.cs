using NicolasAlvarez;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {

        // Primer ejercicio
        Usuario usua = new Usuario();
        Console.WriteLine("Ingrese nombre de usuario:");
        string nom = Console.ReadLine();
        usua.TraerUsuario(nom);
        if (usua.Id != 0)
        {
            Console.WriteLine("Id: {0} ", Convert.ToInt64(usua.Id));
            Console.WriteLine("Nombre: {0}", usua.Nombre.ToString());
            Console.WriteLine("Apellido: {0}", usua.Apellido.ToString());
            Console.WriteLine("NombreUsuario: {0}", usua.NombreUsuario.ToString());
            Console.WriteLine("Contraseña: {0}", usua.Contraseña.ToString());
            Console.WriteLine("Mail: {0}", usua.Mail.ToString());

        }
        else
        {
            Console.WriteLine("Nombre Inexistente!");
        }



        //Segundo ejercicio
        Producto produ = new Producto();
        string iding=string.Empty;
        while (iding == string.Empty)
        {
            Console.WriteLine("Ingrese Idusuario para ver sus productos cargados:");
            iding = Console.ReadLine();
        }
        int idusu = Convert.ToInt32(iding);
        var listapro = produ.TraerProducto(idusu);
        if (listapro.Count > 0)
        {
            foreach (var item in listapro)
            {
                Console.WriteLine("Id: {0} ", Convert.ToInt64(item.Id));
                Console.WriteLine("Descripcion: {0}", item.Descripcion.ToString());
                Console.WriteLine("Costo: {0}", Convert.ToDouble(item.Costo));
                Console.WriteLine("PrecioVenta: {0}", Convert.ToDouble(item.Precioventa));
                Console.WriteLine("Stock: {0}", Convert.ToInt32(item.Stock));
            }
        }
        else
        {
            Console.WriteLine("No tiene productos cargados!");
        }



        //Tercer ejercicio
        Producto prod = new Producto();
        ProductoVendido produv = new ProductoVendido();
        string iding2 = string.Empty;
        while (iding2 == string.Empty)
        {
            Console.WriteLine("Ingrese Idusuario para ver sus productos vendidos:");
            iding2 = Console.ReadLine();
        }
        int idusua = Convert.ToInt32(iding2);
        var listaprod = prod.TraerProducto(idusua);
        if (listaprod.Count > 0)
        {
            foreach (var item in listaprod)
            {
                int idprodv = Convert.ToInt32(item.Id);
                string descrip = item.Descripcion.ToString();
                double preciov = Convert.ToDouble(item.Precioventa);
                var listaprodv = produv.TraerProductoVendido(idprodv, idusua);
                if (listaprodv.Count > 0)
                {
                    foreach (var itempv in listaprodv)
                    {
                        Console.WriteLine("Id: {0} ", Convert.ToInt64(itempv.Id));
                        Console.WriteLine("Idproducto: {0} ", Convert.ToInt64(itempv.Idproducto));
                        Console.WriteLine("Descripcion: {0}", item.Descripcion.ToString());
                        Console.WriteLine("PrecioVenta: {0}", Convert.ToDouble(item.Precioventa));
                        Console.WriteLine("Stock: {0}", Convert.ToInt32(itempv.Stock));
                        Console.WriteLine("Venta: {0}", Convert.ToInt32(itempv.Stock) * Convert.ToDouble(item.Precioventa));
                    }
                }
                else
                {
                    Console.WriteLine("No tiene ventas del producto {0}", item.Descripcion.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("No tiene productos cargados el usuario!");
        }


        //Cuarto ejercicio
        Venta produvu = new Venta();
        string iding3 = string.Empty;
        while (iding3 == string.Empty)
        {
            Console.WriteLine("Ingrese Idusuario para ver sus ventas:");
            iding3 = Console.ReadLine();
        }
        int idusuar = Convert.ToInt32(iding3);
        var listaprodvu = produvu.TraerVenta(idusuar);
        if (listaprodvu.Count > 0)
        {
            foreach (var itempvu in listaprodvu)
            {
                Console.WriteLine("Id: {0} ", Convert.ToInt64(itempvu.Id));
                Console.WriteLine("Idproducto: {0} ", Convert.ToInt64(itempvu.produven.Idproducto));
                Console.WriteLine("Descripcion: {0}", itempvu.produven.productop.Descripcion.ToString());
                Console.WriteLine("PrecioVenta: {0}", Convert.ToDouble(itempvu.produven.productop.Precioventa));
                Console.WriteLine("Stock: {0}", Convert.ToInt32(itempvu.produven.Stock));
                Console.WriteLine("Venta: {0}", Convert.ToInt32(itempvu.produven.Stock) * Convert.ToDouble(itempvu.produven.productop.Precioventa));
                Console.WriteLine("Comentarios: {0}", itempvu.Comentarios.ToString());
            }
        }
        else
        {
            Console.WriteLine("No tiene ventas el usuario");
        }


        //Quinto ejercicio
        Usuario usual = new Usuario();
        Console.WriteLine("Ingrese nombre de usuario:");
        string nomu = Console.ReadLine();
        Console.WriteLine("Ingrese su contraseña:");
        string contra = Console.ReadLine();
        usual.logueo(nomu,contra);
        if (usual.Id != 0)
        {
            Console.WriteLine("Id: {0} ", Convert.ToInt64(usual.Id));
            Console.WriteLine("Nombre: {0}", usual.Nombre.ToString());
            Console.WriteLine("Apellido: {0}", usual.Apellido.ToString());
            Console.WriteLine("NombreUsuario: {0}", usual.NombreUsuario.ToString());
            Console.WriteLine("Contraseña: {0}", usual.Contraseña.ToString());
            Console.WriteLine("Mail: {0}", usual.Mail.ToString());
        }
        else
        {
            Console.WriteLine("Usuario Inexistente!");
        }

    }
}

