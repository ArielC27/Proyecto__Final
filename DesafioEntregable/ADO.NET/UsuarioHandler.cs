using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.Class;

namespace ProyectoFinal.ADO.NET
{
    public class UsuarioHandler : DbHandler
    {
        public Usuario GetUsuarios(string NombreUsuario)
        {
            Usuario usuario = new Usuario();
            // el ConnectionString se encuientra en DBHandler
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Usuario where NombreUsuario = @NombreUsuario";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = NombreUsuario });
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                usuario.Id = Convert.ToInt32(dataReader["ID"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                               usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Email = dataReader["Mail"].ToString();
                            }
                        }
                    }
                    sqlConnection.Close();
                }
           }
            return usuario;
        }
    }
}
