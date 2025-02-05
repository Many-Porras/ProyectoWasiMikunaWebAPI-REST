using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UsuarioData
    {
        public static Usuario LoginUsuario(string email, string password)
        {
            Usuario usuario = null;

            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt64(dr["id_usuario"]),
                                Name = dr["name"].ToString(),
                                Email = dr["email"].ToString(),
                                NameUse = dr["nameUse"].ToString(),
                                FechaRegistro = dr.IsDBNull(dr.GetOrdinal("fecha_registro")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_registro"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores (puedes agregar logs aquí)
                }
            }

            return usuario;
        }

        public static Usuario LoginUsuarioJWT(string email, string password)
        {
            Usuario usuario = null;
            using (SqlConnection conexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt64(dr["id_usuario"]),
                                Name = dr["name"].ToString(),
                                Email = dr["email"].ToString(),
                                NameUse = dr["nameUse"].ToString(),
                                FechaRegistro = dr.IsDBNull(dr.GetOrdinal("fecha_registro")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_registro"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                }
            }
            return usuario;
        }


    }
}