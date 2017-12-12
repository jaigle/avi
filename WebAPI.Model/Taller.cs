using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Model
{
    public class Taller : Entity<int>
    {
        public int IdTaller { get; set; }
        public int IdSucursal { get; set; }
        public string nombreTaller { get; set; }
        public string direccionTaller { get; set; }
        public string encargadoTaller { get; set; }
        public string fonoTaller { get; set; }
        public string emailTaller { get; set; }
    }
}
