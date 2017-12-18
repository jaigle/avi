using System;

namespace WebAPI.Model
{
    public class Anexo : Entity<int>
    {
        public int ctoLo { get; set; }
        public int iDContratoGrupoDF { get; set; }
        public string descripComLo { get; set; }
        public string penaDevAnticipa { get; set; }
        public string multaDevFlota { get; set; }
        public string limiteCoordinaMP { get; set; }
        public string cobCliNoAcudeMP { get; set; }
        public string cobKMAdivDevolAnt { get; set; }
        public string deducibleObs { get; set; }
        public string reempModalidad { get; set; }
        public string cambNeumatico { get; set; }
        public string reempPlazoEnt { get; set; }
        public string roboVehArrend { get; set; }
        public string reempCondicion { get; set; }
        public string roboAccesorioVeh { get; set; }
        public string reempFlotaSuperior10 { get; set; }
        public string reemplFlotaInferior10 { get; set; }
        public string seguroNeumatico { get; set; }
        public string archivos { get; set; }
        public string grupoFlotas { get; set; }
    }
}
