using System.Data;
using System.Data.SqlClient;

namespace DesafioEntregable
{
    public class InicioSesion : DbHandler
    {
        public bool IniciarSesion (string NombreUsuario, string Contraseña)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var querySesion = @"SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario and Contraseña = @Contraseña";
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySesion, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = Contraseña });
                        sqlCommand.ExecuteNonQuery();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                respuesta = true;
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception)
            {
                return respuesta;
            }
            return respuesta;
        }
    }
}


