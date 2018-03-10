USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_EstadoPago_Select]    Script Date: 03/10/2018 03:48:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_EstadoPago_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Drilo_EstadoPago_Select]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_EstadoPago_Select]    Script Date: 03/10/2018 03:48:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Drilo_EstadoPago_Select]
	@IdCliente int,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	SELECT 
	EP.CtoLO  AS ctoLO,
EP.CantVeh_EP  AS cantidadVehiculos,
EP.Num_EP AS numEstadoPago,
EP.CantVeh_EP  AS periodoCreacion,
EP.ObsEP  AS observacion,
EP.ObsEP  AS estado,
EP.PeriodoConsumo  AS periodoConsumo,
EP.TipoDoc  AS tipoDocumento,
EP.NumDoc  AS numDocumento,
EP.MontoNeto_EP  AS monto,
''  AS pathArchivo,
EP.IdCliente  AS idCliente 
	from Central.dbo.Drilo_Estado_Pago AS EP
    WHERE (@IdCliente = 0 OR EP.IdCliente = @IdCliente) 
    
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

