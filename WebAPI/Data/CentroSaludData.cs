using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class CentroSaludData
    {
        public static bool Registrar(CentroSalud oCentroSalud)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_insert_t_centro_salud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oCentroSalud.Nombre);
                cmd.Parameters.AddWithValue("@provincia", oCentroSalud.Provincia);
                cmd.Parameters.AddWithValue("@departamento", oCentroSalud.Departamento);
                cmd.Parameters.AddWithValue("@distrito", oCentroSalud.Distrito);
                cmd.Parameters.AddWithValue("@telefono", oCentroSalud.Telefono);
                cmd.Parameters.AddWithValue("@direccion", oCentroSalud.Direccion);
                cmd.Parameters.AddWithValue("@X", oCentroSalud.X);
                cmd.Parameters.AddWithValue("@Y", oCentroSalud.Y);

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

        public static bool Modificar(CentroSalud oCentroSalud)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_update_t_centro_salud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_centroSalud", oCentroSalud.IdCentroSalud);
                cmd.Parameters.AddWithValue("@nombre", oCentroSalud.Nombre);
                cmd.Parameters.AddWithValue("@provincia", oCentroSalud.Provincia);
                cmd.Parameters.AddWithValue("@departamento", oCentroSalud.Departamento);
                cmd.Parameters.AddWithValue("@distrito", oCentroSalud.Distrito);
                cmd.Parameters.AddWithValue("@telefono", oCentroSalud.Telefono);
                cmd.Parameters.AddWithValue("@direccion", oCentroSalud.Direccion);
                cmd.Parameters.AddWithValue("@X", oCentroSalud.X);
                cmd.Parameters.AddWithValue("@Y", oCentroSalud.Y);

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

        public static List<CentroSalud> Listar()
        {
            List<CentroSalud> oListaCentroSalud = new List<CentroSalud>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_list_t_centro_salud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaCentroSalud.Add(new CentroSalud()
                            {
                                IdCentroSalud = Convert.ToInt32(dr["id_centroSalud"]),
                                Nombre = dr["nombre"].ToString(),
                                Provincia = dr["provincia"].ToString(),
                                Departamento = dr["departamento"].ToString(),
                                Distrito = dr["distrito"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                Direccion = dr["direccion"].ToString(),
                                X = dr["X"].ToString(),
                                Y = dr["Y"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            });
                        }
                    }
                    return oListaCentroSalud;
                }
                catch (Exception ex)
                {
                    return oListaCentroSalud;
                }
            }
        }

        public static CentroSalud Obtener(int id_centroSalud)
        {
            CentroSalud oCentroSalud = new CentroSalud();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_get_t_centro_salud_by_id", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_centroSalud", id_centroSalud);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCentroSalud = new CentroSalud()
                            {
                                IdCentroSalud = Convert.ToInt32(dr["id_centroSalud"]),
                                Nombre = dr["nombre"].ToString(),
                                Provincia = dr["provincia"].ToString(),
                                Departamento = dr["departamento"].ToString(),
                                Distrito = dr["distrito"].ToString(),
                                Telefono = dr["telefono"].ToString(),
                                Direccion = dr["direccion"].ToString(),
                                X = dr["X"].ToString(),
                                Y = dr["Y"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                                FechaUpdate = dr.IsDBNull(dr.GetOrdinal("fecha_update")) ? (DateTime?)null : Convert.ToDateTime(dr["fecha_update"])
                            };
                        }
                    }
                    return oCentroSalud;
                }
                catch (Exception ex)
                {
                    return oCentroSalud;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_t_centro_salud", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_centroSalud", id);

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