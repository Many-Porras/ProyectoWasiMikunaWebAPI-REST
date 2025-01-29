using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class RegionData
    {
        public static List<Region> ListarRegion()
        {
            List<Region> oListaRegion = new List<Region>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRegiones", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaRegion.Add(new Region()
                            {
                                IdRegion = Convert.ToInt32(dr["id_region"]),
                                Nombre = dr["nombre"].ToString(),
                                FechaRegistro = dr.IsDBNull(dr.GetOrdinal("fecha_registro")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            });
                        }

                    }



                    return oListaRegion;
                }
                catch (Exception ex)
                {
                    return oListaRegion;
                }
            }
        }
    }
}