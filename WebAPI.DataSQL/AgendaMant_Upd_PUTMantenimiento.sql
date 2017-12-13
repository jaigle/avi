CREATE PROCEDURE [dbo].[AgendaMant_Upd_PUTMantenimiento] 
	@IdEstadoAgenda int,
	@IdAgenda int,
	@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
	BEGIN TRAN
	UPDATE AgendaMant
	SET IdEstadoAgenda = @IdEstadoAgenda 
	where IdAgenda = @IdAgenda
	
	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'La actualización no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
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