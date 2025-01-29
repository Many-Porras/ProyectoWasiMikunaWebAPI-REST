using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class ColegioData
    {
        public static List<Colegio> ListarColegiosPorDistrito(int id_distrito)
        {
            List<Colegio> colegios = new List<Colegio>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerColegiosPorIdDistrito", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_distrito", id_distrito);

                try
                {
                    oConexion.Open();
                     
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            colegios.Add(new Colegio()
                            {
                                IdColegio = Convert.ToInt32(dr["id_colegio"]),
                                IdDistrito = Convert.ToInt32(dr["id_distrito"]),
                                CodigoModular = dr["codigo_modular"].ToString(),
                                NombreColegio = dr["nombre_colegio"].ToString(),
                                TelefonoColegio = dr["telefono_colegio"].ToString(),
                                DireccionColegio = dr["direccion_colegio"].ToString(),
                                X = dr["X"].ToString(),
                                Y = dr["Y"].ToString(),
                                FechaRegistro = dr.IsDBNull(dr.GetOrdinal("fecha_registro")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja el error según tus necesidades
                }
            }

            return colegios;
        }

    }
}
