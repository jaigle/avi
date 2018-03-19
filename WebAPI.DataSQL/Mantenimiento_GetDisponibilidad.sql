CREATE PROCEDURE [dbo].[Mantenimiento_GetDisponibilidad]
	@IdTaller			int = 1 ,
	@FechaAgenda		datetime 
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
BEGIN TRAN
	declare @CodError int = 0 
	declare @Mensaje  varchar(3000) = ''
	exec @CodError = avis.dbo.AgendaMant_Validacion @Mensaje output, @IdTaller, @FechaAgenda
	select @CodError as disponible, @Mensaje as mensaje

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