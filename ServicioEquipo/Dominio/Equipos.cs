using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioEquipo.Dominio
{
    [DataContract]
    public class Equipos
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Tipo { get; set; }        

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string Estado { get; set; }       

        [DataMember]
        public string FechaReg { get; set; }

        [DataMember]
        public int IdArea { get; set; }

        [DataMember]
        public int IdEstado { get; set; }




    }
}