using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEntregable
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> GetProductoVendido()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido  = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return productosVendidos;
        }
    }
}
