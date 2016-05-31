using ServicioEquipo.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServicioEquipo.Persistencia
{
    public class EquiposDAO
    {
       
        public List<Equipos> ListarEquipos()
        {
            List<Equipos> equiposEncontrado = new List<Equipos>();
            Equipos equipoEncontrado = null;
            string sql = "SELECT nro_serie,e_tipo,e_modelo,EQ.e_descripcion AS descripcion,e_fech_registro,id_area,ES.e_descripcion AS estado from T_Equipos AS EQ INNER JOIN T_Estado AS ES ON EQ.id_estado=ES.id_estado";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            equipoEncontrado = new Equipos()
                            {

                                Id = (string)resultado["nro_serie"],
                                Tipo = (string)resultado["e_tipo"],
                                Modelo = (string)resultado["e_modelo"],
                                Descripcion = (string)resultado["descripcion"],                           
                                IdArea = (int)resultado["id_area"],
                                FechaReg = (string)resultado["e_fech_registro"],
                                Estado = (string)resultado["estado"],
                                
                            };
                            equiposEncontrado.Add(equipoEncontrado);
                        }
                    }

                }

            }
            return equiposEncontrado;
        }




        public Equipos ObtenerEquipos(string id)
        {
            Equipos equipoEncontrado = null;
            string sql = "SELECT nro_serie,e_tipo,e_modelo,EQ.e_descripcion AS descripcion,e_fech_registro,AR.a_descripcion AS area,ES.e_descripcion AS estado from T_Equipos AS EQ INNER JOIN T_Estado AS ES ON EQ.id_estado=ES.id_estado INNER JOIN T_Area AS AR ON EQ.id_area = AR.id_area WHERE nro_serie=@id";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            equipoEncontrado = new Equipos()
                            {
                                Id = (string)resultado["nro_serie"],
                                Tipo = (string)resultado["e_tipo"],
                                Modelo = (string)resultado["e_modelo"],
                                Descripcion = (string)resultado["descripcion"],
                                Area = (string)resultado["area"],
                                FechaReg = (string)resultado["e_fech_registro"],
                                Estado = (string)resultado["estado"]

                            };
                        }
                    }
                }
            }

            return equipoEncontrado;
        }




    }
}