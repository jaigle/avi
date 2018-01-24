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

