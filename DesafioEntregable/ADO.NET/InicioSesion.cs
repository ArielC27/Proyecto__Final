using System.Data;
using System.Data.SqlClient;
using ProyectoFinal.Class;

namespace ProyectoFinal.ADO.NET
{
    public class InicioSesion : DbHandler
    {
        public Usuario IniciarSesion(string NombreUsuario, string Contraseña)
        {
            Usuario usuario = new Usuario();
            // el ConnectionString se encuientra en DBHandler
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var query = @"SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario and Contraseña = @Contraseña";
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = NombreUsuario });
                    sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = Contraseña });
                    sqlCommand.ExecuteNonQuery();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Email = dataReader["Mail"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                            }
                        }
                        else
                        {
                            usuario.Id = 0;
                            usuario.Nombre = "Este Usuario no existe";
                        }
                    }
                }
                sqlConnection.Close();
            }
            return usuario;
        }
    }
}


