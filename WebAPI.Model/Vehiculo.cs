using System;

namespace WebAPI.Model
{
    public class Vehiculo: Entity<int>
    {
        public string flotaPatente { get; set; }
        public string estFloAltaBaja { get; set; }
        public string subCatNomMarca { get; set; }
        public string subCatNomModelo { get; set; }
        public string flotasAnoFrabic { get; set; }
        public string flotasUltKiloEntr { get; set; }
    }
}
