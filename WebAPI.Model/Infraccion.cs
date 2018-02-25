using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Model
{
    public class Infraccion : Entity<int>
    {
        public string nInfraccion { get; set; }
        public string estado { get; set; }
        public string ePAsociado { get; set; }
        public string fechaEP { get; set; }
        public string nContrato { get; set; }
        public string patenteVehiculo { get; set; }
        public string modeloVehiculo { get; set; }
        public string fechaInfraccion { get; set; }
        public string rolCausa { get; set; }
        public string juzgado { get; set; }
        public string observacion { get; set; }
        public string pathArchivo { get; set; }
        public string idCliente { get; set; }
    }
}
