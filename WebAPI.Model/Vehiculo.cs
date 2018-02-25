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
        public string capacidadEstanque { get; set; }
        public string tipoCombustible { get; set; }
        public string kmActualGps { get; set; }
    }
}
