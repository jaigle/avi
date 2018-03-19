USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_OrdenTrabajo_Select]    Script Date: 02/25/2018 04:18:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_OrdenTrabajo_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Drilo_OrdenTrabajo_Select]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Drilo_OrdenTrabajo_Select]    Script Date: 02/25/2018 04:18:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Drilo_OrdenTrabajo_Select]
	@IdCliente int,
	@Patente varchar(50),
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	SELECT OT.NroOT as numeroOT,
	OT.TipoOT as tipo,
	OT.EstdoOT as estado,
	OT.FechaCreacion as fechaCreacion,
	OT.FechaCierre as fechaCierre,
	OT.Taller as taller,
	OT.IdCliente as idCliente,
	OT.Patente as patente
	from Central.dbo.Drilo_OrdenesTrabajo AS OT
    WHERE (@IdCliente = 0 OR OT.IdCliente = @IdCliente) 
    AND (@Patente = '00' OR  OT.Patente = @Patente)
    
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

