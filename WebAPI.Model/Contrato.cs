using System;

namespace WebAPI.Model
{
    public class Contrato: Entity<int>
    {
        private DateTime PeriodoDesde;
        private DateTime PeriodoHasta;
        private DateTime MaxFechaVig;
        

        public string ctoLO { get; set; }
        public string estadoPatentes { get; set; }
        public string descripcion { get; set; }
        public string periodoDesde { get => (PeriodoDesde.ToString("dd-MM-yyyy") == "01-01-0001") ? " " : PeriodoDesde.ToString("dd-MM-yyyy"); }
        public string periodoHasta { get => (PeriodoHasta.ToString("dd-MM-yyyy") == "01-01-0001") ? " " : PeriodoHasta.ToString("dd-MM-yyyy"); }
        public string maxFechaVig  { get => (MaxFechaVig.ToString("dd-MM-yyyy") == "01-01-0001") ? " " : MaxFechaVig.ToString("dd-MM-yyyy"); }
        public string grupoEp { get; set; }
        public string cantidadEp { get; set; }
        public string cantFlotaVig { get; set; }
        public string anexos { get; set; }
    }


    public class ContratoAnexo : Entity<int>
    {
        public string ctoLO { get; set; }
        public string idAnexo { get; set; }
        public string contrato { get; set; }
        public string codCliente { get; set; }
        public string clienteNumero { get; set; }
        public string codEmpresa { get; set; }
        public string modoFacturacion { get; set; }
        public string estadoAnexo { get; set; }
        public string cantPatentes { get; set; }
        public string cantPatentesVigentes { get; set; }
        public string fechaInicio { get; set; }
        public string fechaTermino { get; set; }
    }
}
