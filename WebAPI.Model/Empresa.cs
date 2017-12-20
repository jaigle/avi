using System;

namespace WebAPI.Model
{
    public class Empresa: Entity<int>
    {
        public int clienteNumero { get; set; }
        public string clienteRut { get; set; }
        public string ciudadCodigo { get; set; }
        public string clienteNomRazonSocial { get; set; }
        public string clienteGiro { get; set; }
        public string clienteDirComercial { get; set; }
        public string clienteDirPostal { get; set; }
        public string clienteCodPostal { get; set; }
        public string clienteTelefono { get; set; }
        public string clienteMail { get; set; }
        public string clienteWww { get; set; }
        public string stcCodigo { get; set; }
        public string comunaCodigo { get; set; }
        public string clienteCodigoPais { get; set; }
        public string descCategoria { get; set; }
        public string descRubro { get; set; }
        public string clienteRepresentante { get; set; }
        public string codTipoNegocio { get; set; }
        public int idModoFacturacion { get; set; }
        public int diaFacturacion { get; set; }
        public int diasPago { get; set; }
    }

    public class Empresa_put : Entity<int>
    {
        public int clienteNumero { get; set; }
        public string clienteRut { get; set; }
        public string ciudadCodigo { get; set; }
        public string clienteNomRazonSocial { get; set; }
        public string clienteGiro { get; set; }
        public string clienteDirComercial { get; set; }
        public string clienteCodPostal { get; set; }
        public string clienteTelefono { get; set; }
        public string clienteMail { get; set; }
        public string clienteWww { get; set; }
        public string comunaCodigo { get; set; }
        public string clienteRepresentante { get; set; }
    }
}
