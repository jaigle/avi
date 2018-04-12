USE [Avis]
GO

/****** Object:  StoredProcedure [dbo].[SiniestroFoto_Ins_POSTSiniestroFoto]    Script Date: 04/12/2018 08:08:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SiniestroFoto_Ins_POSTSiniestroFoto] 
(
	@Id int,
	@siniestroId int,
	@path varchar(255),
	@DescError varchar(1000) ='' OUTPUT
)
AS
BEGIN
BEGIN TRAN

 INSERT INTO [Central].[dbo].[Drilo_Siniestro_foto]
           ([id]
           ,[siniestro_id]
           ,[path])
     VALUES
           (@Id
           ,@siniestroId
           ,@path)


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

