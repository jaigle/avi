using System;

namespace WebAPI.Model
{
    public class Flota : Entity<int>
    {
        private DateTime FechaIngreso;
        private DateTime FechaDevolucion;
        private DateTime FechaTermino;
        private DateTime FechaExtension;

        public int idContratoLOGrupoVeh { get; set; }
        public int ctoLo { get; set; }
        public string patente { get; set; }
        public string vigenteAlMesActual { get; set; }
        public string subCatNomMarca { get; set; }
        public string subCatNomModelo { get; set; }
        public string fechaIngreso { get => FechaIngreso.ToString("dd-MM-yyyy"); }
        public string fechaDevolucion { get => FechaDevolucion.ToString("dd-MM-yyyy"); }
        public string fechaTermino { get => FechaTermino.ToString("dd-MM-yyyy"); }
        public string fechaExtension { get => FechaExtension.ToString("dd-MM-yyyy"); }
        public string calidad { get; set; }
        public string cliente { get; set; }

    }
}