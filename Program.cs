using NicolasAlvarez.Models;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {

        // Primer ejercicio
        Usuario usua = new Usuario();
        Console.WriteLine("Ingrese nombre de usuario:");
        string nom = Console.ReadLine();
        var datosusu = usua.TraerUsuario(nom);
        if (datosusu != null)
        {
            Console.WriteLine("Id: {0} ", Convert.ToInt64(datosusu.Id));
            Console.WriteLine("Nombre: {0}", datosusu.Nombre.ToString());
            Console.WriteLine("Apellido: {0}", datosusu.Apellido.ToString());
            Console.WriteLine("NombreUsuario: {0}", datosusu.NombreUsuario.ToString());
            Console.WriteLine("Contraseña: {0}", datosusu.Contraseña.ToString());
            Console.WriteLine("Mail: {0}", datosusu.Mail.ToString());

        }
        else
        {
            Console.WriteLine("Nombre Inexistente!");
        }



        //Segundo ejercicio
        Producto produ = new Producto();
        string iding = string.Empty;
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
        ProductoVendido produv = new ProductoVendido();
        string iding2 = string.Empty;
        while (iding2 == string.Empty)
        {
            Console.WriteLine("Ingrese Idusuario para ver sus productos vendidos:");
            iding2 = Console.ReadLine();
        }
        int idusua = Convert.ToInt32(iding2);
        var listaprod = produv.TraerProductoVendido(idusua);
        if (listaprod.Count > 0)
        {
            foreach (var item in listaprod)
            {
                Console.WriteLine("Id: {0} ", Convert.ToInt64(item.Id));
                Console.WriteLine("Idproducto: {0} ", Convert.ToInt64(item.Idproducto));
                Console.WriteLine("Stock: {0}", Convert.ToInt32(item.Stock));
            }
        }
        else
        {
            Console.WriteLine("No tiene productos vendidos el usuario!");
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
        var datoslog = usual.Logueo(nomu, contra);
        if (datoslog != null)
        {
            Console.WriteLine("Id: {0} ", Convert.ToInt64(datoslog.Id));
            Console.WriteLine("Nombre: {0}", datoslog.Nombre.ToString());
            Console.WriteLine("Apellido: {0}", datoslog.Apellido.ToString());
            Console.WriteLine("NombreUsuario: {0}", datoslog.NombreUsuario.ToString());
            Console.WriteLine("Contraseña: {0}", datoslog.Contraseña.ToString());
            Console.WriteLine("Mail: {0}", datoslog.Mail.ToString());
        }
        else
        {
            Console.WriteLine("Usuario Inexistente!");
        }

    }
}

