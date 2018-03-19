USE [Avis]
GO
/****** Object:  StoredProcedure [dbo].[[Cliente_PUTEmpresa]]    Script Date: 12/18/2017 22:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cliente_PUTEmpresa]
	@clienteNumero varchar(255)
    ,@clienteRut varchar(11)
    ,@ciudadCodigo varchar(20)
    ,@clienteNomRazonSocial varchar(70)
    ,@clienteGiro varchar(500)
    ,@clienteDirComercial varchar(100)
    ,@clienteCodPostal varchar(15)
    ,@clienteTelefono numeric(18,0)
    ,@clienteMail varchar(50)
    ,@clienteWww varchar(30)
    ,@comunaCodigo char(2)
    ,@clienteRepresentante varchar(100)
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN

UPDATE [Avis].[dbo].[clientes]
   SET [Cliente_Rut] = @clienteRut
      ,[Ciudad_Codigo] = @ciudadCodigo
      ,[Cliente_NomRazonSocial] = @clienteNomRazonSocial
      ,[Cliente_Giro] = @clienteGiro
      ,[Cliente_Representante] = @clienteRepresentante
      ,[Cliente_DirComercial] = @clienteDirComercial
      ,[Comuna_Codigo] = @comunaCodigo
      ,[Cliente_CodPostal] = @clienteCodPostal
      ,[Cliente_Telefono] = @clienteTelefono
      ,[Cliente_Mail] = @clienteMail
      ,[Cliente_Www] = @clienteWww
 WHERE [Cliente_Numero] = @clienteNumero

	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'Ocurrió el siguiente Error al actualizar: (error sql' + Cast(@NumError as varchar(15))+ ')'
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
