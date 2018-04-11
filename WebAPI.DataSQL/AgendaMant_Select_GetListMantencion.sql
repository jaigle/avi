USE [Avis]
GO
/****** Object:  StoredProcedure [dbo].[Drilo_AgendaMant_Select_GetListMantencion]    Script Date: 04/11/2018 03:09:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Drilo_AgendaMant_Select_GetListMantencion] 
	@NumCliente integer,
	@IdAgenda integer,
	@token varchar(30),
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
   BEGIN TRAN
	SELECT [IdAgenda] as idAgenda
		  ,EAT.EstadoAgenda AS estadoAgenda
		  ,[PendConf] AS pendConf
		  ,AM.[IdTaller] AS idTaller
		  ,AM.[IdDiaSemana] AS idDiaSemana
		  ,AM.[IdHorario] AS idHorario
		  ,[FechaAgenda] AS fecha
		  ,[Patente] AS patente
		  ,[KilomIndicadoCliente] AS kilomIndicadoCliente
		  ,[ClienteSolReemplazo] AS clienteSolReemplazo
		  ,TS.IdServicio AS descervicio
		  ,[ObsServicio] AS obsServicio
		  ,[NumCliente] As numCliente
		  ,[IdMedioAgenda] AS idMedioAgenda
		  ,[IdContacto] AS idContacto
		  ,Kilom_Veh AS kilomVeh
		  ,[IdSigAgenda] AS idSigAgenda
		  ,Token AS token
		  ,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,HoraDesde,100),7)),7),'AM',' AM'),'PM',' PM') as horaDesde
		  ,REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,HoraHasta,100),7)),7),'AM',' AM'),'PM',' PM') as horaHasta
		  ,CN.Contac_Nombre as contactoNombre
		  ,T.NombreTaller as tallerNombre
	  FROM [AgendaMant] AS AM INNER JOIN EstadoAgendaMant AS EAT on EAT.IdEstadoAgenda = AM.IdEstadoAgenda
	  inner join TipoServicioAgeMant TS ON TS.IdServicio = AM.IdServicio
	  inner join AgendaMant_Horario AH ON AM.IdHorario = AH.IdHorario
	  inner join Avis.dbo.contactoNew CN ON AM.IdContacto = CN.Contac_Numero
	  inner join Avis.dbo.Taller T ON AM.IdTaller = T.IdTaller
	  WHERE ((@IdAgenda = 0) OR (IdAgenda = @IdAgenda)) 
	  AND ((@NumCliente = 0) OR(NumCliente = @NumCliente)) 
	  AND ((@token = '0') OR(Token = @token)) 
	  
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

