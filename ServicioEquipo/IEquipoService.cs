using ServicioEquipo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioEquipo
{
    
    [ServiceContract]
    public interface IEquipoService
    {
        [OperationContract]
        List<Equipos> ListarEquipos();

        [OperationContract]
        Equipos ObtenerEquipos(string id);

    }
}
