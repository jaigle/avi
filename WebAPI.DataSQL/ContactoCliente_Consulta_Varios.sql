CREATE Procedure [dbo].[ContactoCliente_Consulta_Varios]

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