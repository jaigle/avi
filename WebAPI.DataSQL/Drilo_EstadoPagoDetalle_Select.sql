USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_EstadoPagoDetalle_Select]    Script Date: 03/18/2018 01:18:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_EstadoPagoDetalle_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Drilo_EstadoPagoDetalle_Select]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_EstadoPagoDetalle_Select]    Script Date: 03/18/2018 01:18:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Drilo_EstadoPagoDetalle_Select]
	@IdEP int,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	SELECT 
	EP.IdEp  AS nProceso,
EP.PeriodoConsumoPat  AS periodoConsumo,
EP.fhiniciocobro AS fechaInicio,
EP.fhfincobro  AS fechaTermino,
EP.NetoPeso  AS valor,
EP.Patente  AS patente,
EP.ModeloVeh  AS modelo,
EP.MarcaVeh  AS marca,
EP.IdCtoLo  AS idCtoLo,
EP.IdAnexo  AS idAnexo 
	from Central.dbo.Drilo_Estado_PagoDetalle AS EP
    WHERE (EP.IdEP = @IdEP) 
    
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

