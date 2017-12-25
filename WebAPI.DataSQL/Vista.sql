USE [Central]
GO

/****** Object:  View [dbo].[ContratoLO_Vehiculos_Drilo]    Script Date: 12/25/2017 13:43:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_Vehiculos_Drilo]'))
DROP VIEW [dbo].[ContratoLO_Vehiculos_Drilo]
GO

USE [Central]
GO

/****** Object:  View [dbo].[ContratoLO_Vehiculos_Drilo]    Script Date: 12/25/2017 13:43:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[ContratoLO_Vehiculos_Drilo]

--	select * from ContratoLO_Vehiculos_Drilo

as

SELECT clo.CodEmpresa, clo.CtoLO, clo.Item, clo.Patente, clo.FechaIngreso, clo.FechaTermino, clo.FechaDevolucion, clo.FechaExtension, clo.FechaTerminoCalc, clo.VigenteAlMesActual, clo.VigenteHoy, clo.DescVehiculo, clo.IDContratoLo_GrupoVeh, clo.IDContratoloGrupoEP, clo.CodSistUltGrab, clo.FechaUltGrab, clo.CodOpUltGrab, clo.ObsUltGrab, clo.IdCalidad, clo.Pat_Reempl, clo.Periodo_Reempl, clo.iva, clo.valorgps, clo.ParaCobroTag, clo.ValorNeto, clo.CodTipoEntrada, cat.SubCat_NomMarca, cat.SubCat_NomModelo, cal.Descripcion as Calidad
FROM ContratoLO_Vehiculos AS clo with(Nolock)
INNER JOIN avis.dbo.FLOTA AS f with(Nolock) ON clo.Patente COLLATE SQL_Latin1_General_CP1_CI_AS = f.Flotas_Patente 
LEFT OUTER JOIN AdmFlota.dbo.Traslado_CalidadEntrega AS cal with(Nolock) ON clo.IdCalidad = cal.idCalidadEntrega 
LEFT OUTER JOIN avis.dbo.SUBCATEGORIAS AS cat with(Nolock) ON f.SubCat_CodMarcaModelo = cat.SubCat_CodMarcaModelo
--ORDER BY clo.CtoLO DESC



GO

