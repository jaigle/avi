﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Model
{
    public class Mantencion : Entity<int>
    {
        public int Id { get; set; }
        public string idEstadoAgenda { get; set; }
        public string PendConf { get; set; }
        public int idTaller { get; set; }
        public int idDiaSemana { get; set; }
        public int idHorario { get; set; }
        public DateTime Fecha { get; set; }
        public string Patente { get; set; }
        public int kilomIndicadoCliente { get; set; }
        public string ClienteSolReemplazo { get; set; }
        public int IdServicio { get; set; }
        public string ObsServicio { get; set; }
        public int NumCliente { get; set; }
        public string idMedioAgenda { get; set; }
        public int idContacto { get; set; }
        public int kilomVeh { get; set; }
    }

    /// <summary>
    /// Clase para el Get de Mtto
    /// </summary>
    public class MantencionDto : Entity<int>
    {
        public int IdAgenda { get; set; }
        public string estadoAgenda { get; set; }
        public string pendConf { get; set; }
        public int idTaller { get; set; }
        public int idDiaSemana { get; set; }
        public int idHorario { get; set; }
        public DateTime fecha { get; set; }
        public string patente { get; set; }
        public int KilomIndicadoCliente { get; set; }
        public string clienteSolReemplazo { get; set; }
        public string descervicio { get; set; }
        public string obsServicio { get; set; }
        public int numCliente { get; set; }
        public string idMedioAgenda { get; set; }
        public int idContacto { get; set; }
        public int kilomVeh { get; set; }
        public int idSigAgenda { get; set; }
    }


    public class MantencionDisponible : Entity<int>
    {
        public int IdHorario { get; set; }
        public int IdTaller { get; set; }
        public int IdDiaSemana { get; set; }
        public TimeSpan horaDesde { get; set; }
        public TimeSpan horaHasta { get; set; }
        public int cantVehMismoHorario { get; set; }
        public string codSistUltGrab { get; set; }
        public DateTime fechaUltGrab { get; set; }
        public string codOpUltGrab { get; set; }
        public string obsUltGrab { get; set; }
        public int cantMantAgendadas { get; set; }
    }
}