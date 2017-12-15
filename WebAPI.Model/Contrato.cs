using System;

namespace WebAPI.Model
{
    public class Contrato: Entity<int>
    {
        public string ctoLO { get; set; }
        public string estadoPatentes { get; set; }
        public string descripcion { get; set; }
        public string periodoDesde { get; set; }
        public string periodoHasta { get; set; }
        public string maxFechaVig { get; set; }
        public string grupoEp { get; set; }
        public string cantidadEp { get; set; }
        public string cantFlotaVig { get; set; }
    }
}
