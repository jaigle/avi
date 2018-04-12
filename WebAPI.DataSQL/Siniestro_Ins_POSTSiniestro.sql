USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Siniestro_Ins_POSTSiniestro]    Script Date: 04/12/2018 10:54:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Siniestro_Ins_POSTSiniestro] 
(
	@id int,
	@idEmpresa int,
	@patente varchar(20),
	@email varchar(60),
	@denuncianteNombre varchar(255),
	@denuncianteRut varchar(15),
	@denuncianteNacionalidad varchar(30),
	@denuncianteDomicilio varchar(255),
	@denuncianteComuna varchar(60),
	@siniestroFecha date,
	@siniestroHora time(7),
	@siniestroDireccion varchar(255),
	@siniestroCiudad varchar(60),
	@siniestroTipo varchar(30),
	@sinitroTipoOtro varchar(60),
	@siniestroAccion varchar(30),
	@siniestroRelato text,
	@siniestroDano text,
	@ciArchivo varchar(255),
	@licenciaArchivo varchar(255),
	@lesionados bit,
	@unidadPolocial varchar(255),
	@fechaAviso date,
	@horaAviso time(7),
	@numParte varchar(20),
	@numFolio varchar(20),
	@numConstancia varchar(20),
	@citacion bit,
	@citacionFecha date,
	@juzgado varchar(150),
	@constanciaArchivo varchar(20),
	@DescError varchar(1000) ='' OUTPUT
)
AS
BEGIN
BEGIN TRAN
 --DECLARE @Id INTEGER = 0
INSERT INTO [Central].[dbo].[Drilo_Siniestro]
           ([id]
           ,[id_empresa]
           ,[patente]
           ,[email]
           ,[denunciante_nombre]
           ,[denunciante_rut]
           ,[denunciante_nacionalidad]
           ,[denunciante_domicilio]
           ,[denunciante_comuna]
           ,[siniestro_fecha]
           ,[siniestro_hora]
           ,[siniestro_direccion]
           ,[siniestro_ciudad]
           ,[siniestro_tipo]
           ,[sinitro_tipo_otro]
           ,[siniestro_accion]
           ,[siniestro_relato]
           ,[siniestro_dano]
           ,[ci_archivo]
           ,[licencia_archivo]
           ,[lesionados]
           ,[unidad_polocial]
           ,[fecha_aviso]
           ,[hora_aviso]
           ,[num_parte]
           ,[num_folio]
           ,[num_constancia]
           ,[citacion]
           ,[citacion_fecha]
           ,[juzgado]
           ,[constancia_archivo])
     VALUES
           (
            @id,
			@idEmpresa,
			@patente,
			@email,
			@denuncianteNombre,
			@denuncianteRut,
			@denuncianteNacionalidad,
			@denuncianteDomicilio,
			@denuncianteComuna,
			@siniestroFecha,
			@siniestroHora,
			@siniestroDireccion,
			@siniestroCiudad,
			@siniestroTipo,
			@sinitroTipoOtro,
			@siniestroAccion,
			@siniestroRelato,
			@siniestroDano,
			@ciArchivo,
			@licenciaArchivo,
			@lesionados,
			@unidadPolocial,
			@fechaAviso,
			@horaAviso,
			@numParte,
			@numFolio,
			@numConstancia,
			@citacion,
			@citacionFecha,
			@juzgado,
			@constanciaArchivo
			)

 declare @NumError int = 0
 set @NumError= @@Error
 if @NumError<> 0 
 BEGIN
	 set @DescError= 'La inserción no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
	 GOTO SALIR
 END

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

