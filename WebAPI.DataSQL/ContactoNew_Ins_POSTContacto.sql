
CREATE PROCEDURE [dbo].[ContactoNew_Ins_POSTContacto] 
	@Rut char(11),
	@Nombre varchar(200),
	@Contac_Numero numeric(18,2) OUTPUT, 
    @idTipoContacto smallint,
	@Contac_Telefono1 varchar(60),
	@Contac_Mail varchar(100),
	@Contac_Celular varchar(20),
    @Ciudad_Codigo char(20),
	@ContacNumero int = 0,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
SET @Rut = '12492054-K' 
SET @Nombre = 'Testing Name'
	
SELECT @ContacNumero = cn.Contac_Numero FROM contactoNew cn WHERE cn.Contac_RutContacto = @Rut
BEGIN TRAN	
	
if (@ContacNumero <> 0)
BEGIN
	INSERT INTO [contactoCliente]
			   ([Contac_Numero]
			   ,[idTipoContacto]
			   ,[Contac_Telefono1]
			   ,[Contac_Mail]
			   ,[Contac_Celular],
			   Ciudad_Codigo)
		 VALUES
			   (@ContacNumero
			   ,@idTipoContacto
			   ,@Contac_Telefono1
			   ,@Contac_Mail
			   ,@Contac_Celular
			   ,@Ciudad_Codigo)
END
ELSE
BEGIN
	INSERT INTO [contactoNew]
			   ([Contac_Numero]
			   ,[Contac_Nombre]
			   ,[Contac_RutContacto])
				OUTPUT INSERTED.[Contac_Numero]
				VALUES
			   ((SELECT MAX(Contac_Numero)+1 AS NuevoNumero FROM contactoNew),@Nombre, @Rut)

					
	INSERT INTO [contactoCliente]
			   ([Contac_Numero]
			   ,[idTipoContacto]
			   ,[Contac_Telefono1]
			   ,[Contac_Mail]
			   ,[Contac_Celular],
			   Ciudad_Codigo)
		 VALUES
			   (@Contac_Numero
			   ,@idTipoContacto
			   ,@Contac_Telefono1
			   ,@Contac_Mail
			   ,@Contac_Celular
			   ,@Ciudad_Codigo)
END

declare	@NumError int 
set		@NumError = 0
set		@DescError = ''
	
set	@NumError= @@Error
if	@NumError<> 0 
	BEGIN
		set @DescError= 'La inserción no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
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
	--select @DescError
	return (@NumError)
END