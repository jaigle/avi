USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Ins_POSTMantenimiento]    Script Date: 02/12/2018 06:32:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Ins_POSTMantenimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Ins_POSTMantenimiento]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Ins_POSTMantenimiento]    Script Date: 02/12/2018 06:32:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[AgendaMant_Ins_POSTMantenimiento] 
	@IdEstadoAgenda INTEGER,
	@PendConf VARCHAR(5),
	@IdTaller INTEGER,
	@IdDiaSemana INTEGER,
	@IdHorario INTEGER,
	@FechaAgenda DATETIME,
	@Patente VARCHAR(20),
	@KilomIndicadoCliente INT,
	@ClienteSolReemplazo BIT,
	@IdServicio INTEGER,
	@ObsServicio VARCHAR(500),
	@NumCliente INTEGER,
	@IdMedioAgenda INTEGER,
	@IdContacto INTEGER,
	@Kilom_Veh INT,
	@token VARCHAR(30),
	@esMantencion BIT,
    @esReparacion BIT,
    @esSiniestro BIT,
	@DescError	varchar(1000) ='' OUTPUT

AS
BEGIN
	BEGIN TRAN
		DECLARE @IdAgenda INTEGER = 0
		 
		INSERT INTO [AgendaMant]
				   ([IdEstadoAgenda]
				   ,[PendConf]
				   ,[IdTaller]
				   ,[IdDiaSemana]
				   ,[IdHorario]
				   ,[FechaAgenda]
				   ,[Patente]
				   ,[KilomIndicadoCliente]
				   ,[ClienteSolReemplazo]
				   ,[IdServicio]
				   ,[ObsServicio]
				   ,[NumCliente]
				   ,[IdMedioAgenda]
				   ,[IdContacto]
				   ,[Kilom_Veh]
				   ,[EsMantencion]
				   ,[EsReparacion]
				   ,[EsSiniestro]
				   ,[Token]) 
				   OUTPUT INSERTED.IdAgenda          
			 VALUES
				   (
					 @IdEstadoAgenda,
					@PendConf,
					@IdTaller,
					DATEPART(dw,@FechaAgenda),
					@IdHorario,
					@FechaAgenda,
					@Patente,
					@KilomIndicadoCliente,
					@ClienteSolReemplazo,
					@IdServicio,
					@ObsServicio,
					@NumCliente,
					@IdMedioAgenda,
					@IdContacto,
					@Kilom_Veh,
					@esMantencion,
					@esReparacion,
					@esSiniestro,
					@token
				   )
		SET @IdAgenda = @@IDENTITY

		--Creación del registro de Log		   
		INSERT INTO [Avis].[dbo].[AgendaMant_Estados]
           ([IdAgenda]
           ,[IdEstadoAgenda]
           ,[FechaGrabacion]
           ,[CodOperadorGrab]
           ,[ObsGrabacion])
		VALUES
			(@IdAgenda,@IdEstadoAgenda,GETDATE(),'drilo','Grabación desde el portal LO')
           
		declare	@NumError int = 0
		set	@NumError= @@Error
		if	@NumError<> 0 
		BEGIN
			set @DescError= 'La inserciónn no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
			GOTO SALIR
		END

		exec @NumError = avis.dbo.AgendaMant_Upd_Datos @IdAgenda, @DescError output

		if @NumError<> 0 begin
			goto SALIR
		end

	COMMIT TRAN
	goto OK

	SALIR:
		set nocount off

		if @@trancount <> 0 
			ROLLBACK TRAN
		else 
			COMMIT TRAN
	OK:
		return (@NumError)         
END


GO

