using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEntregable
{
    public class InicioSesion : DbHandler
    {
        public void IniciarSesion()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT Usuario AND Contraseña FROM Usuario" +
                " WHERE Contraseña = @contraseña", sqlConnection))
                {
                    sqlConnection.Open();

                }
                sqlConnection.Close();
            }

        }
    }
}
