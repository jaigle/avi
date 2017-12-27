CREATE PROCEDURE [dbo].Contacto_Upd_PUTContacto 
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
			WHERE Contac_Numero = @Contac_Numero AND Cliente_Numero = @Cliente_Numero AND CodTipoNegocio = 2   
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