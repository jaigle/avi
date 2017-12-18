using System;

namespace WebAPI.Model
{
    public class Flota : Entity<int>
    {
        public int idContratoLO_GrupoVeh { get; set; }
        public int ctoLo { get; set; }
        public string patente { get; set; }
        public string vigentesAlMesActual { get; set; }
        public string marcaModelo { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public DateTime fechaTermino { get; set; }
        public DateTime fechaExtension { get; set; }
        public string calidad { get; set; }
    }
}