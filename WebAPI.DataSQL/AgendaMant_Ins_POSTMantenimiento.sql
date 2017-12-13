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
	@DescError	varchar(1000) ='' OUTPUT

AS
BEGIN
	BEGIN TRAN
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
				   ,[Kilom_Veh]) 
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
					@Kilom_Veh
				   )
  declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'La inserciónn no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
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