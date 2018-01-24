CREATE PROCEDURE [dbo].[UsuarioWebDrilo_Select]
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	SELECT [Cliente_Numero] AS clienteNumero
		  ,[Cliente_NomRazonSocial] AS clienteNomRazonSocial
		  ,[Contac_Numero] AS contacNumero
		  ,[Contac_Nombre] AS contacNombre
		  ,[Contac_Mail] AS contacMail
		  ,Stc_Codigo AS stcCodigo
	  FROM [Avis].[dbo].[UsuarioWeb_Drilo]
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

