USE [Avis]
GO
/****** Object:  StoredProcedure [dbo].[ContratoyAnexo_Select]    Script Date: 02/06/2018 23:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ContratoyAnexo_Select]
	@Cliente_Numero			int  
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	declare @Mensaje  varchar(3000) = ''
	
	DECLARE @table TABLE(
	ctoLO  varchar(100),
	idAnexo  varchar(100),
	contrato  varchar(100),
	codCliente  varchar(100),
	clienteNumero  varchar(100),
	codEmpresa  varchar(100),
	modoFacturacion  varchar(100),
	estadoAnexo  varchar(100),
	cantPatentes  varchar(100),
	cantPatentesVigentes  varchar(100),
	fechaInicio  datetime,
	fechaTermino  datetime
	)
	INSERT INTO @table
	exec Central.dbo.ContratosyAnexos_Drilo @Cliente_Numero
	select * from @table
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