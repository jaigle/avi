using System;

namespace WebAPI.Model
{
    public class Siniestro : Entity<int>
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public int patente{ get; set; }
        public int email { get; set; }
        public int denuncianteNombre { get; set; }
        public int denuncianteRut { get; set; }
        public int denuncianteNacionalidad { get; set; }
        public int denuncianteDomicilio { get; set; }
        public int denuncianteComuna { get; set; }
        public int siniestroFecha { get; set; }
        public int siniestroHora { get; set; }
        public int siniestroDireccion { get; set; }
        public int siniestroCiudad { get; set; }
        public int siniestroTipo { get; set; }
        public int sinitroTipoOtro { get; set; }
        public int siniestroAccion { get; set; }
        public int siniestroRelato { get; set; }
        public int siniestroDano { get; set; }
        public int ciArchivo { get; set; }
        public int licenciaArchivo { get; set; }
        public int lesionados { get; set; }
        public int unidadPolocial { get; set; }
        public int fechaAviso { get; set; }
        public int horaAviso { get; set; }
        public int numParte { get; set; }
        public int numFolio { get; set; }
        public int numConstancia { get; set; }
        public int citacion { get; set; }
        public int citacionFecha { get; set; }
        public int juzgado { get; set; }
        public int constanciaArchivo { get; set; }
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
