using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class IncidenciaData
    {

        public static int RegistrarIncidencia(Incidencia oIncidencia)
        {
            int idGenerado = 0;

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarIncidencia", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_colegio", oIncidencia.IdColegio);
                cmd.Parameters.AddWithValue("@tipo_incidencia", oIncidencia.TipoIncidencia);
                cmd.Parameters.AddWithValue("@tipologia", (object)oIncidencia.Tipologia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tipo_doc_reporta", (object)oIncidencia.TipoDocumentoTutor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nro_doc_reporta", (object)oIncidencia.NumeroDocumentoTutor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre_reporta", (object)oIncidencia.NombreTutor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@celular_reporta", (object)oIncidencia.CelularTutor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@detalle_incidencia", (object)oIncidencia.DetalleIncidencia ?? DBNull.Value);
                cmd.Parameters.Add("@archivos", SqlDbType.VarBinary).Value = (object)oIncidencia.Archivos ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@estado", (object)oIncidencia.Estado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_reagendada", (object)oIncidencia.FechaReagendado ?? DBNull.Value);

                try
                {
                    oConexion.Open();
                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al incertar la incidencia: " + ex.Message);
                    // Manejar el error según las necesidades del proyecto
                    idGenerado = 0;
                }
            }

            return idGenerado;
        }


        public static Incidencia Obtener(int id_incidencia)
        {
            Incidencia oIncidencia = new Incidencia();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_get_t_incidencia_by_id", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_incidencia", id_incidencia);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oIncidencia = new Incidencia()
                            {
                                IdIncidencia = Convert.ToInt32(dr["id_incidencia"]),
                                IdColegio = Convert.ToInt32(dr["id_colegio"]),
                                TipoIncidencia = dr["tipo_incidencia"].ToString(),
                                Tipologia = dr["tipologia"].ToString(),
                                TipoDocumentoTutor = dr["tipo_documento_tutor"].ToString(),
                                NumeroDocumentoTutor = dr["numero_documento_tutor"].ToString(),
                                NombreTutor = dr["nombre_tutor"].ToString(),
                                CelularTutor = dr["celular_tutor"].ToString(),
                                Archivos = dr.IsDBNull(dr.GetOrdinal("archivos")) ? null : (byte[])dr["archivos"],
                                Estado = dr["estado"].ToString(),
                                FechaReagendado = dr.IsDBNull(dr.GetOrdinal("fecha_reagendado")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_reagendado"]),
                                FechaRegistro = dr.IsDBNull(dr.GetOrdinal("fecha_registro")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            };
                        }
                    }
                    return oIncidencia;
                }
                catch (Exception ex)
                {
                    return oIncidencia;
                }
            }
        }

        
    }
}