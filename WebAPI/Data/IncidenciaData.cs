using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                    //idGenerado = 0;
                }
            }

            return idGenerado;
        }

        public static List<Incidencia> BuscarPorTipoYNumero(string tipoDoc, string nroDoc)
        {
            List<Incidencia> lista = new List<Incidencia>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarIncidenciasPorTipoNumero", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDoc", tipoDoc);
                cmd.Parameters.AddWithValue("@NroDoc", nroDoc);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(MapearIncidencia(dr));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar incidencias: " + ex.Message);
                }
            }

            return lista;
        }

        public static List<Incidencia> BuscarPorNumero(string nroDoc)
        {
            List<Incidencia> lista = new List<Incidencia>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarIncidenciasPorNroDocumento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroDoc", nroDoc);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(MapearIncidencia(dr));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar incidencias: " + ex.Message);
                }
            }

            return lista;
        }

        private static Incidencia MapearIncidencia(SqlDataReader dr)
        {
            return new Incidencia
            {
                IdIncidencia = Convert.ToInt32(dr["id_incidencia"]),
                IdColegio = Convert.ToInt32(dr["id_colegio"]),
                TipoIncidencia = dr["tipo_incidencia"].ToString(),
                Tipologia = dr["tipologia"].ToString(),
                TipoDocumentoTutor = dr["tipo_doc_reporta"].ToString(),
                NumeroDocumentoTutor = dr["nro_doc_reporta"].ToString(),
                NombreTutor = dr["nombre_reporta"].ToString(),
                CelularTutor = dr["celular_reporta"].ToString(),
                DetalleIncidencia = dr["detalle_incidencia"].ToString(),
                Estado = dr["estado"].ToString(),
                FechaReagendado = dr["fecha_reagendada"] as DateTime?,
                FechaRegistro = dr["fecha_registro"] as DateTime?,
                FechaUpdate = dr["fecha_update"] as DateTime?,
                Colegio = new Colegio
                {
                    IdColegio = Convert.ToInt32(dr["id_colegio"]),
                    NombreColegio = dr["nombre_colegio"].ToString()
                }
            };
        }
    }
}