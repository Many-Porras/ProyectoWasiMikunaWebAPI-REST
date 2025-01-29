using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class ProvinciaData
    {
        public static List<Provincia> ObtenerProvinciasPorRegion(int id_region)
        {
            List<Provincia> provincias = new List<Provincia>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerProvinciasPorIdRegion", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_region", id_region);

                try
                {
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            provincias.Add(new Provincia()
                            {
                                IdProvincia = Convert.ToInt32(dr["id_provincia"]),
                                IdRegion = Convert.ToInt32(dr["id_region"]),
                                NombreProvincia = dr["nombre_provincia"].ToString(),
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

            return provincias;
        }


    }
}