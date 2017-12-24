using System;

namespace WebAPI.Model
{
    public class Ejecutivo: Entity<int>
    {
        public string stcCodigo { get; set; }
        public string stcNombre { get; set; }
        public string stcMail { get; set; }
        public string stcTelefono { get; set; }
        public string stcDireccion { get; set; }
        public string stcCiudad { get; set; }
    }
}
