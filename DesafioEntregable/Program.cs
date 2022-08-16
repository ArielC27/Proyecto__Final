using ProyectoFinal.ADO.NET;

namespace DesafioEntregable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InicioSesion CheckSesiom = new InicioSesion();
            var checkin = CheckSesiom.IniciarSesion("ArielG", "ariel2234");
            if (checkin.Id != 0)
            {
                ///Usuarios ------------------
                //Instancia del controlador 
                UsuarioHandler usuarioHandler = new UsuarioHandler();
                Console.WriteLine("Usuarios: ");
                //Ejecuto GetUsuario y lo almaceno en Usuario.
                var Usuario = usuarioHandler.GetUsuarios("tcasazza");
                //Muestro Usuario
                Console.WriteLine("Id: " + Usuario.Id);
                Console.WriteLine("Nombre: " + Usuario.Nombre);
                Console.WriteLine("Apellido: " + Usuario.Apellido);
                Console.WriteLine("Nombre de Usuario: " + Usuario.NombreUsuario);
                Console.WriteLine("Contraseña: " + Usuario.Contraseña);
                Console.WriteLine("Mail: " + Usuario.Email);
                Console.WriteLine("***");
                Console.WriteLine();

                //Producto ------------------
                //Instancia del controlador 
                ProductoHandler productoHandler = new ProductoHandler();
                Console.WriteLine("Productos: ");
                //Ejecuto GetProducto y lo almaceno en Usuario.
                foreach (var producto in productoHandler.GetProductos(Usuario.Id))
                {
                    //Muestro Producto
                    Console.WriteLine("Id: " + producto.Id);
                    Console.WriteLine("Descripción: " + producto.Descripcion);
                    Console.WriteLine("Costo: $" + producto.Costo);
                    Console.WriteLine("Precio de venta: $" + producto.PrecioVenta);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Id Usuario: " + producto.IdUsuario);
                    Console.WriteLine("***");
                    Console.WriteLine();
                }

                //Producto Vendido
                ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
                Console.WriteLine("Productos Vendidos: ");
                foreach (var item in productoVendidoHandler.GetProductoVendido(Usuario.Id))
                {
                    Console.WriteLine("Stock: " + item.Stock);
                    Console.WriteLine("Id Venta:" + item.IdVenta);
                    Console.WriteLine("Id Producto: " + item.IdProducto.Id);
                    Console.WriteLine("Descripción: " + item.IdProducto.Descripcion);
                    Console.WriteLine("Costo: $" + item.IdProducto.Costo);
                    Console.WriteLine("Precio de Venta: $" + item.IdProducto.PrecioVenta);
                    Console.WriteLine("Stock restante: " + item.IdProducto.Stock);
                    Console.WriteLine("***");
                }
                Console.ReadLine();

                //Venta ------------------
                //Instancia del controlador 
                VentasHandler ventasHandler = new VentasHandler();
                Console.WriteLine("Ventas: ");
                //Ejecuto GetUsuario y lo almaceno en Usuario.
                foreach (var venta in ventasHandler.GetVentas(Usuario.Id))
                {
                    Console.WriteLine("Id: " + venta.Id);
                    Console.WriteLine("Comentarios: " + venta.Comentarios);
                    Console.WriteLine("***");
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine(checkin.Nombre);
            }
            Console.ReadLine();
        }
    }

}