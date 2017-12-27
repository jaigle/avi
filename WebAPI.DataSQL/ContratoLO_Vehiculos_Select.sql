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
FechaExtension AS fechaExtension, FechaTermino AS fechaTermino, Calidad AS calidad, CD.Cliente_NomRazonSocial AS cliente
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
