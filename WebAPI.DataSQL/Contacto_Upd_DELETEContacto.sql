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

