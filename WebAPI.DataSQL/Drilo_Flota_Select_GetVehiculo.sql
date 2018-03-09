USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_Flota_Select_GetVehiculo]    Script Date: 02/25/2018 04:21:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_Flota_Select_GetVehiculo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Drilo_Flota_Select_GetVehiculo]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_Flota_Select_GetVehiculo]    Script Date: 02/25/2018 04:21:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Drilo_Flota_Select_GetVehiculo]
 @Patente varchar(50)
,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	select F.Flotas_Patente as flotaPatente, 
	E.EstFlo_Nombre as estFloAltaBaja, 
	S.SubCat_NomMarca as subCatNomMarca, 
	S.SubCat_NomModelo as subCatNomModelo, 
	F.Flotas_AnoFabric as flotasAnoFrabic, 
	F.Flotas_UltKiloEntr as flotasUltKiloEntr,
	ISNULL(v.CapacidadEstanque,'0') as capacidadEstanque, 
	ISNULL(V.TipoCombustible,'Sin Especificar') as tipoCombustible,
	ISNULL(v.KmActualGPS,'0') as kmActualGps,
	v.CtoLO as ctoLO,
	v.IdAnexo as idAnexo,
	v.Cliente_Numero as clienteNumero,
	v.FechaIngreso as fechaIngreso,
	v.FechaTermino as fechaTermino,
	v.FechaDevolucion as fechaDevolucion,
	v.FechaExtension as fechaExtension,
	v.ValorNeto as valorNeto,
	v.Calidad as calidad
	from Flota as F inner join ESTADOFLOTA as E on F.Flotas_Estado = E.EstFlo_COdigo
	inner join SUBCATEGORIAS as S on F.SubCat_CodMarcaModelo = S.SubCat_CodMarcaModelo
	left outer join Central.dbo.ContratoLO_Vehiculos_Drilo as v on v.Patente = F.Flotas_Patente COLLATE Modern_Spanish_CS_AS
	where F.Flotas_Patente = @Patente
	
	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'Ocurrió el siguiente Error: (error sql' + Cast(@NumError as varchar(15))+ ')'
			GOTO SALIR
		END
	COMMIT TRAN
	goto OK

	SALIR:
		set nocount off
		if @@rowcount<>0 
			ROLLBACK TRAN
		else 
			COMMIT TRAN
	OK:
		return (@NumError)
END
GO

