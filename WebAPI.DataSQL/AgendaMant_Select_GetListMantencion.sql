CREATE PROCEDURE [dbo].[AgendaMant_Select_GetListMantencion] 
	@NumCliente integer,
	@IdAgenda integer,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
   BEGIN TRAN
	SELECT [IdAgenda]
		  ,EAT.EstadoAgenda AS estadoAgenda
		  ,[PendConf]
		  ,[IdTaller]
		  ,[IdDiaSemana]
		  ,[IdHorario]
		  ,[FechaAgenda] AS Fecha
		  ,[Patente]
		  ,[KilomIndicadoCliente]
		  ,[ClienteSolReemplazo]
		  ,TS.IdServicio AS descervicio
		  ,[ObsServicio]
		  ,[NumCliente]
		  ,[IdMedioAgenda]
		  ,[IdContacto]
		  ,[IdSigAgenda]
	  FROM [AgendaMant] AS AM INNER JOIN EstadoAgendaMant AS EAT on EAT.IdEstadoAgenda = AM.IdEstadoAgenda
	  inner join TipoServicioAgeMant TS ON TS.IdServicio = AM.IdServicio
	  WHERE ((@IdAgenda = 0) OR (IdAgenda = @IdAgenda)) AND ((@NumCliente = 0) OR(NumCliente = @NumCliente)) 
	  
	  declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'La búsqueda no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
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

