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
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public DateTime fechaTermino { get; set; }
        public DateTime fechaExtension { get; set; }
        public string calidad { get; set; }
        public string codEmpresa { get; set; }
    }
}