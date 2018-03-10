USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_Reemplazo_Select]    Script Date: 03/10/2018 03:41:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_Reemplazo_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Drilo_Reemplazo_Select]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_Reemplazo_Select]    Script Date: 03/10/2018 03:41:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Drilo_Reemplazo_Select]
	@IdCliente int,
	@Patente varchar(50),
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	SELECT 
	R.PatenteTitular AS patenteVehiculo,
    R.ModeloVehTit      AS modeloVehiculoTitular,
    NumCto     AS ctoLO,
    PatenteReemp     AS patenteVehiculoReemplazo,
    DescMotReemp     AS motivo,
    ActaEntrega     AS actaEntrega,
    ReempFInicio     AS fechaTrasladoEntrega,
    ReempFTermino     AS fechaTrasladoDevolucion,
    ActaDevol    AS actaRecepcion,
    IdCliente     AS idCliente
	from Central.dbo.Drilo_Reemplazos AS R
    WHERE (@IdCliente = 0 OR R.IdCliente = @IdCliente) 
    AND (@Patente = '00' OR  R.PatenteTitular = @Patente)

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

