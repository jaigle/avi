﻿CREATE PROCEDURE ContratoLO_Vehiculos_Select
	@IdContrato int
	,@IdGrupoVehiculo int
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN

select IDContratoloGrupoEP AS iDContratoloGrupoEP, CtoLO AS ctoLO, Patente AS patente, VigenteAlMesActual AS vigenteAlMesActual, 
'' AS marcaModelo,FechaIngreso AS fechaIngreso, FechaDevolucion AS fechaDevolucion, 
FechaExtension AS fechaExtension, FechaTermino AS fechaTermino, '' AS calidad
FROM central.dbo.ContratoLO_Vehiculos_Drilo AS Pcpal    
WHERE ((@IdContrato = 0) OR (Pcpal.CtoLO = @IdContrato)) AND ((@IdGrupoVehiculo = 0) OR (Pcpal.IDContratoLo_GrupoVeh = @IdGrupoVehiculo))
   
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
END