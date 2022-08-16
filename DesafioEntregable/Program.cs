using ProyectoFinal.ADO.NET;

namespace DesafioEntregable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();
            productoHandler.GetProductos();

            UsuarioHandler usuarioHandler = new UsuarioHandler();
            usuarioHandler.GetUsuarios();

            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
            productoVendidoHandler.GetProductoVendido();

            VentasHandler ventasHandler = new VentasHandler();
            ventasHandler.GetVentas();
            
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.NombreUsuario = "ArielG";
            inicioSesion.Contraseña = "ariel1234";
            inicioSesion.IniciarSesion();
        }
    }
}