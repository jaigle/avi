using System;

namespace WebAPI.Model
{
    public class Siniestro : Entity<int>
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public string patente { get; set; }
        public string email { get; set; }
        public string denuncianteNombre { get; set; }
        public string denuncianteRut { get; set; }
        public string denuncianteNacionalidad { get; set; }
        public string denuncianteDomicilio { get; set; }
        public string denuncianteComuna { get; set; }
        public string siniestroFecha { get; set; }
        public string siniestroHora { get; set; }
        public string siniestroDireccion { get; set; }
        public string siniestroCiudad { get; set; }
        public string siniestroTipo { get; set; }
        public string siniestroTipoOtro { get; set; }
        public string siniestroAccion { get; set; }
        public string siniestroRelato { get; set; }
        public string siniestroDano { get; set; }
        public string ciArchivo { get; set; }
        public string licenciaArchivo { get; set; }
        public int lesionados { get; set; }
        public string unidadPolicial { get; set; }
        public string fechaAviso { get; set; }
        public string horaAviso { get; set; }
        public string numParte { get; set; }
        public string numFolio { get; set; }
        public string numConstancia { get; set; }
        public int citacion { get; set; }
        public string citacionFecha { get; set; }
        public string juzgado { get; set; }
        public string constanciaArchivo { get; set; }
        public string siniestro_expediente { get; set; }
        public string siniestroVelocidad { get; set; }
        public string siniestroComuna { get; set; }
        public string culpable { get; set; }
        public string denuncianteCiudad { get; set; }

        public string citacionArchivo { get; set; }
        public string siniestroGrua { get; set; }
        public string terceros { get; set; }
    }

    public class SiniestroFoto : Entity<int>
    {
        public int Id { get; set; }
        public int siniestroId { get; set; }
        public string path { get; set; }
    }

    public class SiniestroTercero : Entity<int>
    {
        public int Id { get; set; }
        public int siniestroId { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string patente { get; set; }
        public string marcas { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
    }
}
