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
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public int IdArea { get; set; }

        [DataMember]
        public int IdEstado { get; set; }




    }
}