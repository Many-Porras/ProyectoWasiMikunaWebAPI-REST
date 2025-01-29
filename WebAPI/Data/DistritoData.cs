using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class DistritoData
    {
        public static List<Distrito> ListarDistritosPorProvincia(int id_provincia)
        {
            List<Distrito> distritos = new List<Distrito>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDistritoPorIdProvincia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_provincia", id_provincia);

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            distritos.Add(new Distrito()
                            {
                                IdDistrito = Convert.ToInt32(dr["id_distrito"]),
                                IdProvincia = Convert.ToInt32(dr["id_provincia"]),
                                NombreDistrito = dr["nombre"].ToString(),
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

            return distritos;
        }

        public static Distrito ObtenerDistritoPorCoordenadas(double longitud, double latitud)
        {
            Distrito distrito = null;

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerDistritoPorCoordenadas", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Longitud", longitud);
                cmd.Parameters.AddWithValue("@Latitud", latitud);

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            distrito = new Distrito()
                            {
                                IdDistrito = Convert.ToInt32(dr["iddistrito"]),
                                IdProvincia = Convert.ToInt32(dr["idprovincia"]),
                                // Agrega más campos si es necesario
                                IdRegion = Convert.ToInt32(dr["idregion"]),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Maneja el error según tus necesidades
                }
            }

            return distrito;
        }


    }
}