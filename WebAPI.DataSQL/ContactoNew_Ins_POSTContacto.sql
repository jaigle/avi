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
					   ,Ciudad_Codigo
					   ,Contac_Estado
					   )
				 VALUES
					   (@Contac_Numero
					   ,@idTipoContacto
					   ,@Contac_Telefono1
					   ,@Contac_Mail
					   ,@Contac_Celular
					   ,(SELECT MAX(Cliente_Numero)+1 FROM contactoCliente)
					   ,2
					   ,@Ciudad_Codigo
					   ,'Activo')
		END
		ELSE
		BEGIN
			SELECT @Cliente_Numero = cc.Cliente_Numero FROM [contactoCliente] cc WHERE 
			cc.Contac_Numero = @Contac_Numero AND cc.CodTipoNegocio = 2 
			AND cc.idTipoContacto = @idTipoContacto
			
			IF ((@Cliente_Numero  is null) OR (@Cliente_Numero = 0))
			BEGIN
			INSERT INTO [contactoCliente]
					   ([Contac_Numero]
					   ,[idTipoContacto]
					   ,[Contac_Telefono1]
					   ,[Contac_Mail]
					   ,[Contac_Celular]
					   ,Cliente_Numero
					   ,CodTipoNegocio
					   ,Ciudad_Codigo
					   ,Contac_Estado
					   )
				 VALUES
					   (@Contac_Numero 
					   ,@idTipoContacto 
					   ,@Contac_Telefono1 
					   ,@Contac_Mail  
					   ,@Contac_Celular 
					   ,@Cliente_Numero 
					   ,@CodigoTipoNegocio 				
					   ,@Ciudad_Codigo
					   ,'Activo')			   
			END
			ELSE
			BEGIN
				UPDATE [contactoCliente]
				SET Contac_Estado = 'Activo'
			END
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