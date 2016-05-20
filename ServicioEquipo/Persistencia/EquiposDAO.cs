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

        private string CadenaConexion = "Data Source=305a4753-766f-4c06-b100-a60c0046e39d.sqlserver.sequelizer.com;Database=db305a4753766f4c06b100a60c0046e39d;Initial Catalog=db305a4753766f4c06b100a60c0046e39d;User Id=oytjmyrazbvivilj; Password=ToLz4HuFLd3g7XqckzCHPQc6QPYDsgzupYqpUqQ8KpTzdHcfTXjyZZNdkPSnSYnE";

        public List<Equipos> ListarEquipos()
        {
            List<Equipos> equiposEncontrado = new List<Equipos>();
            Equipos equipoEncontrado = null;
            string sql = "SELECT id_equipo,nombre, EQ.descripcion AS detalle,marca,id_area,precio,fechregistro,ES.descripcion AS estado FROM Equipos  AS EQ INNER JOIN Estado AS ES ON EQ.id_estado=ES.id_estado";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
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

                                Id = (int)resultado["id_equipo"],
                                Nombre = (string)resultado["nombre"],
                                Descripcion = (string)resultado["detalle"],
                                Marca = (string)resultado["marca"],
                                IdArea = (int)resultado["id_area"],
                                Precio = (decimal)resultado["precio"],
                                fecha = (DateTime)resultado["fechregistro"],
                                Estado = (string)resultado["estado"],
                                
                            };
                            equiposEncontrado.Add(equipoEncontrado);
                        }
                    }

                }

            }
            return equiposEncontrado;
        }




        public Equipos ObtenerEquipos(int id)
        {
            Equipos equipoEncontrado = null;
            string sql = "SELECT id_equipo,nombre, EQ.descripcion AS detalle,marca,AR.descripcion AS area,precio,fechregistro,ES.descripcion AS estado FROM Equipos  AS EQ INNER JOIN Estado AS  ES ON EQ.id_estado=ES.id_estado INNER JOIN Area AS AR ON EQ.id_area = AR.id_area WHERE id_equipo=@id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
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
                                Id = (int)resultado["id_equipo"],
                                Nombre = (string)resultado["nombre"],
                                Descripcion = (string)resultado["detalle"],
                                Marca = (string)resultado["marca"],
                                Area = (string)resultado["area"],
                                Precio = (decimal)resultado["precio"],
                                fecha = (DateTime)resultado["fechregistro"],
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