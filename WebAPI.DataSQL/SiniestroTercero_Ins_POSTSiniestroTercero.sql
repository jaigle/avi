USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[SiniestroTercero_Ins_POSTSiniestroTercero]    Script Date: 04/12/2018 08:14:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SiniestroTercero_Ins_POSTSiniestroTercero] 
(
	@Id int
    ,@siniestroId int
    ,@nombre varchar(255)
    ,@telefono varchar(20)
    ,@email varchar(60)
    ,@patente varchar(20)
    ,@marcas text
    ,@modelo varchar(150)
    ,@ano int
	,@DescError varchar(1000) ='' OUTPUT
)
AS
BEGIN
BEGIN TRAN
 --DECLARE @Id INTEGER = 0
INSERT INTO [Central].[dbo].[Drilo_Siniestro_tercero]
           ([id]
           ,[siniestro_id]
           ,[nombre]
           ,[telefono]
           ,[email]
           ,[patente]
           ,[marcas]
           ,[modelo]
           ,[ano])
     VALUES
           (
			@Id
			,@siniestroId
			,@nombre
			,@telefono
			,@email
			,@patente
			,@marcas
			,@modelo
			,@ano
		   )


 declare @NumError int = 0
 set @NumError= @@Error
 if @NumError<> 0 
 BEGIN
	 set @DescError= 'La inserción no se realizó  (error sql' + Cast(@NumError as varchar(15))+ ')'
	 GOTO SALIR
 END

 if @NumError<> 0 begin
 goto SALIR
 end

COMMIT TRAN
goto OK

SALIR:
 set nocount off

 if @@trancount <> 0 
 ROLLBACK TRAN
 else 
 COMMIT TRAN
OK:
 return (@NumError)         
END
GO

