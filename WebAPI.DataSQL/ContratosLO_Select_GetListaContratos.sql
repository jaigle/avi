ALTER PROCEDURE ContratoLO_Select_GetContratos
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
