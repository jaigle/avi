using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Model
{
    public class OrdenTrabajo : Entity<int>
    {
        public string numeroOT { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaCierre { get; set; }
        public string taller { get; set; }
        public string idCliente { get; set; }
        public string patente { get; set; }
    }
}
