using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Class
{
    public class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }
        public Producto IdProducto { get; set; }
        public ProductoVendido()
        {
            Producto producto = new Producto();
            IdProducto = producto;
        }
    }
}
