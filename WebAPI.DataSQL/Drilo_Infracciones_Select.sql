USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_Infracciones_Select]    Script Date: 02/25/2018 04:17:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_Infracciones_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Drilo_Infracciones_Select]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_Infracciones_Select]    Script Date: 02/25/2018 04:17:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Drilo_Infracciones_Select]
	@IdCliente int,
	@Patente varchar(50),
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN

	SELECT 
	I.InfracID	as nInfraccion,
	I.StatusInfraRecobDesc	as estado,
	I.IdEp	as ePAsociado,
	I.PeridoConsumoEP as fechaEP,
	I.IdCtoLO	as nContrato,
	I.Patente as patenteVehiculo,
	I.SubCat_NomModelo	as modeloVehiculo,
	I.FecInfrac	as fechaInfraccion,
	I.RolCausa	as rolCausa,
	I.JuzgadoDescrip	as juzgado,
	I.StatusInfraRecobDesc	as observacion,
	I.UrlAdjunto as pathArchivo,
	I.Cliente_Numero	as idCliente,
	I.IdAnexo as nAnexo
	from Central.dbo.Drilo_Infracciones as I
    WHERE (@IdCliente = 0 OR I.Cliente_Numero = @IdCliente)     
    AND (@Patente = '00' OR  I.Patente = @Patente)
    
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

