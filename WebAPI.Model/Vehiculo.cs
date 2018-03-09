using System;

namespace WebAPI.Model
{
    public class Vehiculo: Entity<int>
    {
        private DateTime FechaIngreso;
        private DateTime FechaTermino;
        private DateTime FechaDevolucion;
        private DateTime FechaExtension;

        public string flotaPatente { get; set; }
        public string estFloAltaBaja { get; set; }
        public string subCatNomMarca { get; set; }
        public string subCatNomModelo { get; set; }
        public string flotasAnoFrabic { get; set; }
        public string flotasUltKiloEntr { get; set; }
        public string capacidadEstanque { get; set; }
        public string tipoCombustible { get; set; }
        public string kmActualGps { get; set; }
        public string ctoLO { get; set; }
        public string idAnexo { get; set; }
        public string clienteNumero { get; set; }
        public string fechaIngreso { get => (FechaIngreso.ToString("dd-MM-yyyy") == "01-01-0001 0:00") ? " " : FechaIngreso.ToString("dd-MM-yyyy HH:mm"); }
        public string fechaTermino { get => (FechaTermino.ToString("dd-MM-yyyy") == "01-01-0001 0:00") ? " " : FechaTermino.ToString("dd-MM-yyyy HH:mm"); }
        public string fechaDevolucion { get => (FechaDevolucion.ToString("dd-MM-yyyy") == "01-01-0001 0:00") ? " " : FechaDevolucion.ToString("dd-MM-yyyy HH:mm"); }
        public string fechaExtension { get => (FechaExtension.ToString("dd-MM-yyyy") == "01-01-0001 0:00") ? " " : FechaExtension.ToString("dd-MM-yyyy HH:mm"); }
        public string valorNeto { get; set; }
        public string calidad { get; set; }
    }
}
