Create PROCEDURE [dbo].[ContactoNew_Ins_POSTContacto] 
	@Rut varchar(11),
	@Nombre varchar(200),
	@Contac_Numero numeric(18,0), 
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
	set nocount on	
	SELECT @Contac_Numero = cn.Contac_Numero FROM contactoNew cn WHERE cn.Contac_RutContacto = @Rut
	BEGIN TRAN	
	
		if (@Contac_Numero <> 0)
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
					   --(2864,2,'string','string@222.com','string',55555555, 2,'ADUANA QUILLAGUA    ')
					   
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
					   ,2				--PENDIENTE POR DEFINIR ESTOS DOS
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