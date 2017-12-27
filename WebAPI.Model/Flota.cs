using System;

namespace WebAPI.Model
{
    public class Flota : Entity<int>
    {
        public int idContratoLOGrupoVeh { get; set; }
        public int ctoLo { get; set; }
        public string patente { get; set; }
        public string vigenteAlMesActual { get; set; }
        public string subCatNomMarca { get; set; }
        public string subCatNomModelo { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaDevolucion { get; set; }
        public string fechaTermino { get; set; }
        public string fechaExtension { get; set; }
        public string calidad { get; set; }
        public string cliente { get; set; }
    }
}