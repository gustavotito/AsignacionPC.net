using ServicioEquipo.Dominio;
using ServicioEquipo.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioEquipo
{
    
    public class EquipoService : IEquipoService
    {
        EquiposDAO equiposDAO =new EquiposDAO();

        public List<Equipos> ListarEquipos()
        {
            return equiposDAO.ListarEquipos();
        }


        public Equipos ObtenerEquipos(int id)
        {
            return equiposDAO.ObtenerEquipos(id);
        }




    }
}
