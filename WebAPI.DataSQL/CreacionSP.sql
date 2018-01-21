USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Cliente_Select_GetEmpresa]    Script Date: 12/29/2017 08:48:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente_Select_GetEmpresa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Cliente_Select_GetEmpresa]
GO

/****** Object:  StoredProcedure [dbo].[Contacto_Upd_DELETEContacto]    Script Date: 12/29/2017 08:48:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contacto_Upd_DELETEContacto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contacto_Upd_DELETEContacto]
GO

/****** Object:  StoredProcedure [dbo].[ContactoNew_Ins_POSTContacto]    Script Date: 12/29/2017 08:48:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactoNew_Ins_POSTContacto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContactoNew_Ins_POSTContacto]
GO

/****** Object:  StoredProcedure [dbo].[Contacto_Upd_PUTContacto]    Script Date: 12/29/2017 08:48:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contacto_Upd_PUTContacto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contacto_Upd_PUTContacto]
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_GrupoDF_Select]    Script Date: 12/29/2017 08:48:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_GrupoDF_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContratoLO_GrupoDF_Select]
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_Vehiculos_Select]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_Vehiculos_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContratoLO_Vehiculos_Select]
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_Select_GetContratos]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_Select_GetContratos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContratoLO_Select_GetContratos]
GO

/****** Object:  StoredProcedure [dbo].[UsuarioWebDrilo_Select]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioWebDrilo_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UsuarioWebDrilo_Select]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Ins_POSTMantenimiento]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Ins_POSTMantenimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Ins_POSTMantenimiento]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Select_GetListMantencion]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Select_GetListMantencion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Select_GetListMantencion]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Upd_PUTMantenimiento]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Upd_PUTMantenimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Upd_PUTMantenimiento]
GO

/****** Object:  StoredProcedure [dbo].[Cliente_PUTEmpresa]    Script Date: 12/29/2017 08:48:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente_PUTEmpresa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Cliente_PUTEmpresa]
GO

/****** Object:  StoredProcedure [dbo].[Contacto_Select_GetListaContactos]    Script Date: 12/29/2017 08:48:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contacto_Select_GetListaContactos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contacto_Select_GetListaContactos]
GO

/****** Object:  StoredProcedure [dbo].[ContactoTipo_Consulta_Varios]    Script Date: 12/29/2017 08:48:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactoTipo_Consulta_Varios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContactoTipo_Consulta_Varios]
GO

/****** Object:  StoredProcedure [dbo].[ContactoCliente_Consulta_Varios]    Script Date: 12/29/2017 08:48:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactoCliente_Consulta_Varios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContactoCliente_Consulta_Varios]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Cliente_Select_GetEmpresa]    Script Date: 12/29/2017 08:48:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cliente_Select_GetEmpresa] 
	@ClienteRut varchar(11),
	@NumeroCliente int
AS
BEGIN
SELECT top 1
C.[Cliente_Numero] AS clienteNumero
      ,[Cliente_Rut] AS clienteRut
      ,[Ciudad_Codigo] AS ciudadCodigo
      ,[Cliente_NomRazonSocial] AS clienteNomRazonSocial
      ,[Cliente_Giro] AS clienteGiro
      ,[Cliente_DirComercial] AS clienteDirComercial
      ,[Cliente_DirPostal] AS clienteDirPostal
      ,[Cliente_CodPostal] AS clienteCodPostal
      ,[Cliente_Telefono] AS clienteTelefono
      ,[Cliente_Mail]	 AS clienteMail
      ,[Cliente_Www] AS clienteWww
      ,[Stc_Codigo] AS stcCodigo
      ,[Comuna_Codigo] AS comunaCodigo
      ,[Cliente_CodigoPais] AS clienteCodigoPais
      ,C.DescCateg AS descCategoria
      ,C.DescRubro AS descRubro
      ,[Cliente_Representante] AS clienteRepresentante
      ,CodTipoNegocio
      ,F.descripcion AS descModoFacturacion
      ,diaFacturacion
      ,diasPago
      ,C.OC as oc
      ,C.HES as hes
  FROM cliente_drilo AS C INNER JOIN facturacionModo AS F ON F.idModoFacturacion = C.idModoFacturacion
  WHERE ((C.Cliente_Rut = @ClienteRut) OR (@ClienteRut = '0')) AND ((@NumeroCliente = 0) OR (C.Cliente_Numero = @NumeroCliente))
END




GO

/****** Object:  StoredProcedure [dbo].[Contacto_Upd_DELETEContacto]    Script Date: 12/29/2017 08:48:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Contacto_Upd_DELETEContacto] 
	@Contac_Numero numeric(18,0) OUTPUT, 
    @idTipoContacto smallint,
    @Cliente_Numero numeric (18,0),
	@DescError	varchar(1000) OUTPUT
AS
BEGIN
    DECLARE @Correlativo int
    
	set nocount on	
	BEGIN TRAN	
		BEGIN
			UPDATE contactoCliente SET
			Contac_Estado = 'Inactivo'
			WHERE Contac_Numero = @Contac_Numero AND Cliente_Numero = @Cliente_Numero AND CodTipoNegocio = 2  AND  idTipoContacto = @idTipoContacto
		END


		declare	@NumError int 
		set		@NumError = 0
		set		@DescError = ''
			
		set	@NumError= @@Error
		if	@NumError<> 0 
			BEGIN
				set @DescError= ' La desactivación no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
				GOTO SALIR
			END
	COMMIT TRAN
	set nocount on
-- control de errores --------------------
goto OK

SALIR:
	set nocount off
	if @@rowcount <> 0 
		rollback transaction 
	else 
		commit transaction 
OK:
	return (@NumError)
-------------------------------------
END

GO

/****** Object:  StoredProcedure [dbo].[ContactoNew_Ins_POSTContacto]    Script Date: 12/29/2017 08:48:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContactoNew_Ins_POSTContacto] 
	@Rut varchar(11),
	@Nombre varchar(200),
	@Contac_Numero numeric(18,0) OUTPUT, 
	@CodigoTipoNegocio numeric(18,0),
    @idTipoContacto smallint,
	@Contac_Telefono1 varchar(60),
	@Contac_Mail varchar(100),
	@Contac_Celular varchar(20),
    @Ciudad_Codigo char(20),
    @Cliente_Numero numeric (18,0),
	@DescError	varchar(1000) OUTPUT
AS
BEGIN
    DECLARE @Correlativo int
    
	set nocount on	
	SELECT @Contac_Numero = cn.Contac_Numero FROM contactoNew cn WHERE cn.Contac_RutContacto = @Rut
	BEGIN TRAN	
		if ((@Contac_Numero is null) OR (@Contac_Numero = 0))
		BEGIN
			SET @Contac_Numero = (SELECT MAX(Contac_Numero)+1 FROM contactoNew)
			INSERT INTO [contactoNew]
					   ([Contac_Numero]
					   ,[Contac_Nombre]
					   ,[Contac_RutContacto])
						VALUES
					   (@Contac_Numero
					   ,@Nombre
					   ,@Rut)

							
			INSERT INTO [contactoCliente]
					   ([Contac_Numero]
					   ,[idTipoContacto]
					   ,[Contac_Telefono1]
					   ,[Contac_Mail]
					   ,[Contac_Celular]
					   ,Cliente_Numero
					   ,CodTipoNegocio
					   ,Ciudad_Codigo
					   ,Contac_Estado
					   )
				 VALUES
					   (@Contac_Numero
					   ,@idTipoContacto
					   ,@Contac_Telefono1
					   ,@Contac_Mail
					   ,@Contac_Celular
					   ,(SELECT MAX(Cliente_Numero)+1 FROM contactoCliente)
					   ,2
					   ,@Ciudad_Codigo
					   ,'Activo')
		END
		ELSE
		BEGIN
			SELECT @Cliente_Numero = cc.Cliente_Numero FROM [contactoCliente] cc WHERE 
			cc.Contac_Numero = @Contac_Numero AND cc.CodTipoNegocio = 2 
			AND cc.idTipoContacto = @idTipoContacto
			
			IF ((@Cliente_Numero  is null) OR (@Cliente_Numero = 0))
			BEGIN
			INSERT INTO [contactoCliente]
					   ([Contac_Numero]
					   ,[idTipoContacto]
					   ,[Contac_Telefono1]
					   ,[Contac_Mail]
					   ,[Contac_Celular]
					   ,Cliente_Numero
					   ,CodTipoNegocio
					   ,Ciudad_Codigo
					   ,Contac_Estado
					   )
				 VALUES
					   (@Contac_Numero 
					   ,@idTipoContacto 
					   ,@Contac_Telefono1 
					   ,@Contac_Mail  
					   ,@Contac_Celular 
					   ,@Cliente_Numero 
					   ,@CodigoTipoNegocio 				
					   ,@Ciudad_Codigo
					   ,'Activo')			   
			END
			ELSE
			BEGIN
				UPDATE [contactoCliente]
				SET Contac_Estado = 'Activo'
			END
		END


		declare	@NumError int 
		set		@NumError = 0
		set		@DescError = ''
			
		set	@NumError= @@Error
		if	@NumError<> 0 
			BEGIN
				set @DescError= ' La inserción no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
				GOTO SALIR
			END
	COMMIT TRAN
	set nocount on
-- control de errores --------------------
goto OK

SALIR:
	set nocount off
	if @@rowcount <> 0 
		rollback transaction 
	else 
		commit transaction 
OK:
	return (@NumError)
-------------------------------------
END
GO

/****** Object:  StoredProcedure [dbo].[Contacto_Upd_PUTContacto]    Script Date: 12/29/2017 08:48:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Contacto_Upd_PUTContacto] 
	@Contac_Numero numeric(18,0) OUTPUT, 
    @idTipoContacto smallint,
	@Contac_Telefono1 varchar(60),
	@Contac_Mail varchar(100),
	@Contac_Celular varchar(20),
    @Ciudad_Codigo char(20),
    @Cliente_Numero numeric (18,0),
	@DescError	varchar(1000) OUTPUT
AS
BEGIN
    DECLARE @Correlativo int
    
	set nocount on	
	BEGIN TRAN	
		BEGIN
			UPDATE contactoCliente SET
			Contac_Telefono1 = @Contac_Telefono1,
			Contac_Celular = @Contac_Celular,
			Contac_Mail = @Contac_Mail,
			Ciudad_Codigo = @Ciudad_Codigo
			WHERE Contac_Numero = @Contac_Numero AND Cliente_Numero = @Cliente_Numero AND CodTipoNegocio = 2  AND  idTipoContacto = @idTipoContacto
		END


		declare	@NumError int 
		set		@NumError = 0
		set		@DescError = ''
			
		set	@NumError= @@Error
		if	@NumError<> 0 
			BEGIN
				set @DescError= ' La actualización no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
				GOTO SALIR
			END
	COMMIT TRAN
	set nocount on
-- control de errores --------------------
goto OK

SALIR:
	set nocount off
	if @@rowcount <> 0 
		rollback transaction 
	else 
		commit transaction 
OK:
	return (@NumError)
-------------------------------------
END
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_GrupoDF_Select]    Script Date: 12/29/2017 08:48:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoLO_GrupoDF_Select]
	@IdContrato int
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN

SELECT
[IDContratoloGrupoDF] AS iDContratoloGrupoDF
      ,[CtoLO] AS ctoLO
      ,[idTipoContrato] AS idTipoContrato
      ,[DescripComLO] AS descripComLO
      ,[PenaDevAnticipa] AS penaDevAnticipa
      ,[MultaDevFlota] AS multaDevFlota
      ,[LimiteCoordinaMP] AS limiteCoordinaMP
      ,[CobCliNoAcudeMP] AS cobCliNoAcudeMP
      ,[CobKmAdicDevolAnt] AS cobKmAdicDevolAnt
      ,[DeducibleObs] AS deducibleObs
      ,[ReempModalidad] AS reempModalidad
      ,[ReempPlazoEnt] AS reempPlazoEnt
      ,[ReempCondicion] AS reempCondicion
      ,[ReempFlotaSuperior10] AS reempFlotaSuperior10
      ,[ReempFlotaInferior10] AS reempFlotaInferior10      
      ,[CambNeumatico] AS cambNeumatico
      ,[RoboVehArrend] AS roboVehArrend
      ,[SeguroNeumatico] AS seguroNeumatico
      ,ISNULL((select '['+stuff((
	select ',{"urlAdjunto": "'+CONVERT(varchar,cg.UrlAdjunto)+'","fechaUltGrab": "'+CONVERT(varchar,cg.FechaUltGrab)+'"}'
	from Historico.dbo.Archivos_Adjuntos cg where cg.TipoOrigen = 'DOCLO' AND cg.NumOrigen = Principal.[CtoLO]  AND cg.NumOrigen2 = Principal.[IDContratoloGrupoDF] 
	for XML Path('')),1,1,'')+']'),'No Presenta') as archivos
      ,(select '['+stuff((
	select 
	',{"idContratoLoGrupoVeh": "'+CONVERT(varchar,A.IDContratoLo_GrupoVeh)
	+'","grupoDescrip": "'+CONVERT(varchar,A.GrupoDescrip)
	+'","nombreModelo": "'+CONVERT(varchar,B.NombreModelo)
	+'","flotaCantidad": "'+CONVERT(varchar,ISNULL(A.FlotaCantidad,0))
	+'","cantFlotaAsig": "'+CONVERT(varchar,ISNULL(A.CantFlotaAsig,0))
	+'","servGPS": "'+CONVERT(varchar,A.ServGPS)
	+'","costoServGPSUF": "'+CONVERT(varchar,ISNULL(A.CostoServGPS_UF,0))
	+'","valMenVehUF": "'+CONVERT(varchar,A.ValMenVeh_UF)
	+'","duracionMeses": "'+CONVERT(varchar,A.Duracion_Meses)
	+'"}'
	FROM [Central].[dbo].[ContratoLO_GrupoVeh] as A
  INNER JOIN Central.dbo.LO_Modelo as B ON B.idModelo = A.IdModelo
  WHERE A.IDContratoloGrupoDF = Principal.[IDContratoloGrupoDF]
	for XML Path('')),1,1,'')+']') AS grupoFlotas
	
  FROM [Central].[dbo].[ContratoLO_GrupoDF] AS Principal
  where IDContratoloGrupoDF = @IdContrato
    
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

/****** Object:  StoredProcedure [dbo].[ContratoLO_Vehiculos_Select]    Script Date: 12/29/2017 08:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoLO_Vehiculos_Select]
	@IdContrato int
	,@IdGrupoVehiculo int
	,@IdCliente int
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN

select IDContratoLo_GrupoVeh AS idContratoLOGrupoVeh, CtoLO AS ctoLO, Patente AS patente, VigenteAlMesActual AS vigenteAlMesActual, 
SubCat_NomMarca AS subCatNomMarca,SubCat_NomModelo AS subCatNomModelo,FechaIngreso AS fechaIngreso, FechaDevolucion AS fechaDevolucion, 
FechaExtension AS fechaExtension, FechaTermino AS fechaTermino, Calidad AS calidad, Pcpal.CodEmpresa AS cliente
FROM central.dbo.ContratoLO_Vehiculos_Drilo AS Pcpal INNER JOIN cliente_drilo AS CD ON Pcpal.Cliente_Numero = CD.Cliente_Numero
WHERE ((@IdContrato = 0) OR (Pcpal.CtoLO = @IdContrato))
AND ((@IdCliente = 0) OR (Pcpal.Cliente_Numero = @IdCliente) ) 
AND ((@IdGrupoVehiculo = 0) OR (Pcpal.IDContratoLo_GrupoVeh = @IdGrupoVehiculo))
   
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

/****** Object:  StoredProcedure [dbo].[ContratoLO_Select_GetContratos]    Script Date: 12/29/2017 08:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoLO_Select_GetContratos]
	@CodEmpresa int
AS	
BEGIN
	select c.CtoLO as ctoLO, c.EstadoPatentes as estadoPatentes
	,(select fm.descripcion from facturacionCondiciones AS fact inner join facturacionModo fm on fm.idModoFacturacion = fact.idModoFacturacion
where CodTipoNegocio = 2 AND Cliente_Numero = c.Cliente_Numero) as descripcion  
	,c.PeriodoDesde as periodoDesde,c.PeriodoHasta as periodoHasta,c.MaxFechaVigencia as maxFechaVig,c.GrupoEp as grupoEp
	,c.CantEp as cantidadEp,c.CantFlotaVigAlMes as cantFlotaVig
	, (select '['+stuff((
	select ',{"idContratoloGrupoDF": "'+CONVERT(varchar,cg.IDContratoloGrupoDF)+'","descripComLO": "'+cg.DescripComLO+'"}'
	from Central.dbo.ContratoLO_GrupoDF cg where cg.CtoLO = c.CtoLO for XML Path('')),1,1,'')+']') as anexos
	from Central.dbo.ContratoLO c
	where c.Cliente_Numero = @CodEmpresa
END
GO

/****** Object:  StoredProcedure [dbo].[UsuarioWebDrilo_Select]    Script Date: 12/29/2017 08:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioWebDrilo_Select]
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	SELECT [Cliente_Numero] AS clienteNumero
		  ,[Cliente_NomRazonSocial] AS clienteNomRazonSocial
		  ,[Contac_Numero] AS contacNumero
		  ,[Contac_Nombre] AS contacNombre
		  ,[Contac_Mail] AS contacMail
		  ,Stc_Codigo AS stcCodigo
	  FROM [Avis].[dbo].[UsuarioWeb_Drilo]
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

/****** Object:  StoredProcedure [dbo].[AgendaMant_Ins_POSTMantenimiento]    Script Date: 12/29/2017 08:48:38 ******/
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
		--Creación del registro de Log		   
		INSERT INTO [Avis].[dbo].[AgendaMant_Estados]
           ([IdAgenda]
           ,[IdEstadoAgenda]
           ,[FechaGrabacion]
           ,[CodOperadorGrab]
           ,[ObsGrabacion])
     VALUES
           (@@IDENTITY,@IdEstadoAgenda,GETDATE(),'drilo','Grabación desde el portal LO')
           
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
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Select_GetListMantencion]    Script Date: 12/29/2017 08:48:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgendaMant_Select_GetListMantencion] 
	@NumCliente integer,
	@IdAgenda integer,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
   BEGIN TRAN
	SELECT [IdAgenda] as idAgenda
		  ,EAT.EstadoAgenda AS estadoAgenda
		  ,[PendConf] AS pendConf
		  ,[IdTaller] AS idTaller
		  ,[IdDiaSemana] AS idDiaSemana
		  ,[IdHorario] AS idHorario
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

/****** Object:  StoredProcedure [dbo].[AgendaMant_Upd_PUTMantenimiento]    Script Date: 12/29/2017 08:48:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgendaMant_Upd_PUTMantenimiento] 
	@IdEstadoAgenda int,
	@IdAgenda int,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
	BEGIN TRAN
	UPDATE AgendaMant
	SET IdEstadoAgenda = @IdEstadoAgenda 
	where IdAgenda = @IdAgenda
	
	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'La actualización no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
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

/****** Object:  StoredProcedure [dbo].[Cliente_PUTEmpresa]    Script Date: 12/29/2017 08:48:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Cliente_PUTEmpresa]
	@clienteNumero varchar(255)
    ,@clienteRut varchar(11)
    ,@ciudadCodigo varchar(20)
    ,@clienteNomRazonSocial varchar(70)
    ,@clienteGiro varchar(500)
    ,@clienteDirComercial varchar(100)
    ,@clienteCodPostal varchar(15)
    ,@clienteTelefono numeric(18,0)
    ,@clienteMail varchar(50)
    ,@clienteWww varchar(30)
    ,@comunaCodigo char(2)
    ,@clienteRepresentante varchar(100)
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN

UPDATE [Avis].[dbo].[clientes]
   SET [Cliente_Rut] = @clienteRut
      ,[Ciudad_Codigo] = @ciudadCodigo
      ,[Cliente_NomRazonSocial] = @clienteNomRazonSocial
      ,[Cliente_Giro] = @clienteGiro
      ,[Cliente_Representante] = @clienteRepresentante
      ,[Cliente_DirComercial] = @clienteDirComercial
      ,[Comuna_Codigo] = @comunaCodigo
      ,[Cliente_CodPostal] = @clienteCodPostal
      ,[Cliente_Telefono] = @clienteTelefono
      ,[Cliente_Mail] = @clienteMail
      ,[Cliente_Www] = @clienteWww
 WHERE [Cliente_Numero] = @clienteNumero

	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'Ocurrió el siguiente Error al actualizar: (error sql' + Cast(@NumError as varchar(15))+ ')'
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

/****** Object:  StoredProcedure [dbo].[Contacto_Select_GetListaContactos]    Script Date: 12/29/2017 08:48:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Contacto_Select_GetListaContactos]
	@IdEmpresa int,
	@Contac_Numero int,
	@IdTipoContacto int
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
SELECT cc.Contac_Numero AS contacNumero, cc.Cliente_Numero AS clienteNumero, cn.Contac_Nombre AS contacNombre,
       cn.Contac_RutContacto AS contacRutContacto, tc.descripcion, cc.Contac_Telefono1 AS contacTelefono1, cc.Contac_Celular AS contacCelular,
       cc.Contac_Mail AS contacMail, cc.Ciudad_Codigo AS ciudadCodigo, cc.idTipoContacto AS idTipoContacto 
  FROM contactoNew cn INNER JOIN contactoCliente cc ON cc.Contac_Numero = cn.Contac_Numero
INNER JOIN tipoContacto tc ON tc.idTipoContacto = cc.idTipoContacto
WHERE cc.CodTipoNegocio = 2 AND contac_estado = 'Activo' 
AND (@IdEmpresa = 0 OR @IdEmpresa = cc.Cliente_Numero )
AND (@IdTipoContacto = 0 OR @IdTipoContacto = cc.idTipoContacto )
AND (@Contac_Numero = 0 OR @Contac_Numero = cc.Contac_Numero )

	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'Ocurrió el siguiente Error: (error sql' + Cast(@NumError as varchar(15))+ ')'
			GOTO SALIR
		END
	goto OK

	SALIR:
		set nocount off
	OK:
		return (@NumError)
END

GO

/****** Object:  StoredProcedure [dbo].[ContactoTipo_Consulta_Varios]    Script Date: 12/29/2017 08:48:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create Procedure [dbo].[ContactoTipo_Consulta_Varios]

@contac_numero int,
@cliente_numero int

--ContactoTipo_Consulta_Varios 3 , 50879
as
begin
	select			ct.codTipoNegocio	as codNegocio,
					ct.idTipoContacto	as codTipo,
					n.Negoci_Nombre		as negocio,
					tc.glosa			as tipo

	from			avis.dbo.clienteContactoRol ct
	left outer join avis.dbo.NEGOCIOS n
	on				ct.CodTipoNegocio	= n.Negoci_Codigo
	left outer join	avis.dbo.tipoContacto tc
	on				ct.IdTipoContacto	= tc.idTipoContacto
	where			contac_numero		= @contac_numero
	and				Cliente_Numero		= @cliente_numero
End

GO

/****** Object:  StoredProcedure [dbo].[ContactoCliente_Consulta_Varios]    Script Date: 12/29/2017 08:48:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create Procedure [dbo].[ContactoCliente_Consulta_Varios]

@contac_numero int,
@cliente_numero int

as
begin

	if		@contac_numero	= 0	 set @contac_numero = null
	if		@cliente_numero	= 0	 set @cliente_numero = null

	select		cc.contac_numero		as id,
				cn.Contac_RutContacto	as rut,
				cn.Contac_Nombre		as nombre,
				cn.Contac_FecCumpleanos as cumpleanos,
				cc.Contac_Estado		as estado,
				cc.Contac_DirComercial	as dirComercial,
				cc.Contac_DirPostal		as dirPostal,
				cc.Ciudad_Codigo		as ciudadCod,
				cc.Ciudad_Codigo		as ciudad,
				co.Comuna_Nombre		as comuna,
				cc.Comuna_Codigo		as comunaCod,
				cc.Contac_Telefono1		as fono1,
				cc.Contac_Telefono2		as fono2,
				cc.Contac_Anexo			as anexo,
				cc.Contac_Celular		as celular,
				cc.Contac_Mail			as mail,
				cc.Contac_Fax			as fax

		from		avis.dbo.clienteContacto cc
		left outer join	avis.dbo.contactoNew cn
		on			cc.Contac_Numero = cn.Contac_Numero
		left outer  join	avis.dbo.comunas co
		on			cc.Comuna_Codigo = co.Comuna_Codigo
		left outer  join	avis.dbo.CIUDADES ci
		on			cc.Ciudad_Codigo = ci.Ciudad_Codigo

	where		cc.contac_numero = coalesce(@contac_numero,cc.contac_numero)
	and			cc.Cliente_Numero = coalesce(@cliente_numero,cc.Cliente_Numero)
End

GO

