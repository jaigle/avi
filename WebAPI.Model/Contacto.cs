﻿using System;

namespace WebAPI.Model
{
    public class ContactoDto: Entity<int>
    {
        public ContactoDto()
        {
            codigoTipoNegocio = 2;
        }

        public int contacNumero { get; set; }
        public int clienteNumero { get; set; }
        public int codigoTipoNegocio{ get; set; }
        public int idTipoContacto { get; set; }
        public string contacNombre { get; set; }
        public string contacRutContacto { get; set; }
        public string telefono1 { get; set; }
        public string contacCelular { get; set; }
        public string contacMail { get; set; }
        public string ciudadCodigo { get; set; }
    }

    public class ContactoNew : Entity<int>
    {
        public int contacNumero { get; set; }
        public string contacNombre { get; set; }
        public string contacRutContacto { get; set; }
    }


    public class ContactoCliente : Entity<int>
    {
        public int contacNumero { get; set; }
        public int clienteNumero { get; set; }
        public string idTipoContacto { get; set; }
        public string telefono1 { get; set; }
        public string contacCelular { get; set; }
        public string contacMail { get; set; }
        public string ciudadCodigo { get; set; }
    }

    public class ContactoEmpresa : Entity<int>
    {
        public string contacNumero { get; set; }
        public string clienteNumero { get; set; }
        public string contacNombre { get; set; }
        public string contacRutContacto { get; set; }
        public string descripcion { get; set; }
        public string contacTelefono1 { get; set; }
        public string contacCelular { get; set; }
        public string contacMail { get; set; }
        public string ciudadCodigo { get; set; }
        public string idTipoContacto { get; set; }
    }

    public class TipoContacto : Entity<int>
    {
        public int idTipoContacto { get; set; }
        public string descripcion { get; set; }
    }

    public class Usuario : Entity<int>
    {
        public string clienteNumero { get; set; }
        public string clienteNomRazonSocial { get; set; }
        public string contacNumero { get; set; }
        public string contacNombre { get; set; }
        public string contacMail { get; set; }
        public string stcCodigo { get; set; }
    }
}