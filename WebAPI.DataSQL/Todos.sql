USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Contacto_Select_GetListaContactos]    Script Date: 12/25/2017 13:42:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contacto_Select_GetListaContactos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Contacto_Select_GetListaContactos]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Ins_POSTMantenimiento]    Script Date: 12/25/2017 13:42:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Ins_POSTMantenimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Ins_POSTMantenimiento]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Select_GetListMantencion]    Script Date: 12/25/2017 13:42:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Select_GetListMantencion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Select_GetListMantencion]
GO

/****** Object:  StoredProcedure [dbo].[AgendaMant_Upd_PUTMantenimiento]    Script Date: 12/25/2017 13:42:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendaMant_Upd_PUTMantenimiento]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AgendaMant_Upd_PUTMantenimiento]
GO

/****** Object:  StoredProcedure [dbo].[Cliente_PUTEmpresa]    Script Date: 12/25/2017 13:42:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente_PUTEmpresa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Cliente_PUTEmpresa]
GO

/****** Object:  StoredProcedure [dbo].[Cliente_Select_GetEmpresa]    Script Date: 12/25/2017 13:42:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente_Select_GetEmpresa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Cliente_Select_GetEmpresa]
GO

/****** Object:  StoredProcedure [dbo].[ContactoNew_Ins_POSTContacto]    Script Date: 12/25/2017 13:42:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactoNew_Ins_POSTContacto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContactoNew_Ins_POSTContacto]
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_GrupoDF_Select]    Script Date: 12/25/2017 13:42:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_GrupoDF_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContratoLO_GrupoDF_Select]
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_Vehiculos_Select]    Script Date: 12/25/2017 13:42:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_Vehiculos_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContratoLO_Vehiculos_Select]
GO

/****** Object:  StoredProcedure [dbo].[ContratoLO_Select_GetContratos]    Script Date: 12/25/2017 13:42:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContratoLO_Select_GetContratos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContratoLO_Select_GetContratos]
GO

USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[Contacto_Select_GetListaContactos]    Script Date: 12/25/2017 13:42:29 ******/
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
SELECT cc.Contac_Numero AS contactNumero, cc.Cliente_Numero AS clienteNumero, cn.Contac_Nombre AS contacNombre,
       cn.Contac_RutContacto AS contacRutContacto, tc.descripcion, cc.Contac_Telefono1 AS contacTelefono1, cc.Contac_Celular AS contacCelular,
       cc.Contac_Mail AS contacMail, cc.Ciudad_Codigo AS ciudadCodigo
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

/****** Object:  StoredProcedure [dbo].[AgendaMant_Ins_POSTMantenimiento]    Script Date: 12/25/2017 13:42:34 ******/
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

/****** Object:  StoredProcedure [dbo].[AgendaMant_Select_GetListMantencion]    Script Date: 12/25/2017 13:42:43 ******/
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

/****** Object:  StoredProcedure [dbo].[AgendaMant_Upd_PUTMantenimiento]    Script Date: 12/25/2017 13:42:44 ******/
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

/****** Object:  StoredProcedure [dbo].[Cliente_PUTEmpresa]    Script Date: 12/25/2017 13:42:45 ******/
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

/****** Object:  StoredProcedure [dbo].[Cliente_Select_GetEmpresa]    Script Date: 12/25/2017 13:42:47 ******/
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

/****** Object:  StoredProcedure [dbo].[ContactoNew_Ins_POSTContacto]    Script Date: 12/25/2017 13:42:47 ******/
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
					   ,Ciudad_Codigo)
				 VALUES
					   (@Contac_Numero
					   ,@idTipoContacto
					   ,@Contac_Telefono1
					   ,@Contac_Mail
					   ,@Contac_Celular
					   ,(SELECT MAX(Cliente_Numero)+1 FROM contactoCliente)
					   ,2
					   ,@Ciudad_Codigo)
		END
		ELSE
		BEGIN
			INSERT INTO [contactoCliente]
					   ([Contac_Numero]
					   ,[idTipoContacto]
					   ,[Contac_Telefono1]
					   ,[Contac_Mail]
					   ,[Contac_Celular]
					   ,Cliente_Numero
					   ,CodTipoNegocio
					   ,Ciudad_Codigo)
				 VALUES
					   (@Contac_Numero 
					   ,@idTipoContacto 
					   ,@Contac_Telefono1 
					   ,@Contac_Mail  
					   ,@Contac_Celular 
					   ,@Cliente_Numero 
					   ,@CodigoTipoNegocio 				
					   ,@Ciudad_Codigo)				   
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

/****** Object:  StoredProcedure [dbo].[ContratoLO_GrupoDF_Select]    Script Date: 12/25/2017 13:42:48 ******/
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

/****** Object:  StoredProcedure [dbo].[ContratoLO_Vehiculos_Select]    Script Date: 12/25/2017 13:42:49 ******/
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
FechaExtension AS fechaExtension, FechaTermino AS fechaTermino, Calidad AS calidad, CodEmpresa AS codEmpresa
FROM central.dbo.ContratoLO_Vehiculos_Drilo AS Pcpal    
WHERE ((@IdContrato = 0) OR (Pcpal.CtoLO = @IdContrato))
AND ((@IdCliente = 0) OR (Pcpal.CodEmpresa = @IdCliente) ) 
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

/****** Object:  StoredProcedure [dbo].[ContratoLO_Select_GetContratos]    Script Date: 12/25/2017 13:42:50 ******/
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
	,c.PeriodoDesde as periodoDesde,c.PeriodoHasta as periodoHasta,'' as MaxFechaVig,c.GrupoEp
	,'' as CantidadEp,'' as CantFlotaVig
	, (select '['+stuff((
	select ',{"idContratoloGrupoDF": "'+CONVERT(varchar,cg.IDContratoloGrupoDF)+'","descripComLO": "'+cg.DescripComLO+'"}'
	from Central.dbo.ContratoLO_GrupoDF cg where cg.CtoLO = c.CtoLO for XML Path('')),1,1,'')+']') as anexos
	from Central.dbo.ContratoLO c
	where c.Cliente_Numero = @CodEmpresa
END

GO

