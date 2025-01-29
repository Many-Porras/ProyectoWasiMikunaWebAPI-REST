using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DetalleIncidenciaData
    {
        public static bool Registrar(DetalleIncidencia oDetalleIncidencia)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_insert_t_detalle_incidencia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_incidencia", oDetalleIncidencia.IdIncidencia);
                cmd.Parameters.AddWithValue("@id_usuario", oDetalleIncidencia.IdUsuario);
                cmd.Parameters.AddWithValue("@detalle_incidencia", oDetalleIncidencia.DetalleIncidenciaTexto);
                cmd.Parameters.AddWithValue("@comentario", oDetalleIncidencia.Comentario);
                cmd.Parameters.AddWithValue("@estado", oDetalleIncidencia.Estado);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(DetalleIncidencia oDetalleIncidencia)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_update_t_detalle_incidencia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_detalle_incidencia", oDetalleIncidencia.IdDetalleIncidencia);
                cmd.Parameters.AddWithValue("@id_incidencia", oDetalleIncidencia.IdIncidencia);
                cmd.Parameters.AddWithValue("@id_usuario", oDetalleIncidencia.IdUsuario);
                cmd.Parameters.AddWithValue("@detalle_incidencia", oDetalleIncidencia.DetalleIncidenciaTexto);
                cmd.Parameters.AddWithValue("@comentario", oDetalleIncidencia.Comentario);
                cmd.Parameters.AddWithValue("@estado", oDetalleIncidencia.Estado);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<DetalleIncidencia> Listar()
        {
            List<DetalleIncidencia> oListaDetalleIncidencia = new List<DetalleIncidencia>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_list_t_detalle_incidencia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaDetalleIncidencia.Add(new DetalleIncidencia()
                            {
                                IdDetalleIncidencia = Convert.ToInt32(dr["id_detalle_incidencia"]),
                                IdIncidencia = Convert.ToInt32(dr["id_incidencia"]),
                                IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                                DetalleIncidenciaTexto = dr["detalle_incidencia"].ToString(),
                                Comentario = dr["comentario"].ToString(),
                                Estado = dr["estado"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            });
                        }
                    }
                    return oListaDetalleIncidencia;
                }
                catch (Exception ex)
                {
                    return oListaDetalleIncidencia;
                }
            }
        }

        public static DetalleIncidencia Obtener(int id_detalle_incidencia)
        {
            DetalleIncidencia oDetalleIncidencia = new DetalleIncidencia();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_get_t_detalle_incidencia_by_id", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_detalle_incidencia", id_detalle_incidencia);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oDetalleIncidencia = new DetalleIncidencia()
                            {
                                IdDetalleIncidencia = Convert.ToInt32(dr["id_detalle_incidencia"]),
                                IdIncidencia = Convert.ToInt32(dr["id_incidencia"]),
                                IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                                DetalleIncidenciaTexto = dr["detalle_incidencia"].ToString(),
                                Comentario = dr["comentario"].ToString(),
                                Estado = dr["estado"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            };
                        }
                    }
                    return oDetalleIncidencia;
                }
                catch (Exception ex)
                {
                    return oDetalleIncidencia;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_t_detalle_incidencia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_detalle_incidencia", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}