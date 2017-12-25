CREATE PROCEDURE [dbo].[Contacto_Select_GetListaContactos]
	@IdEmpresa int,
	@Contac_Numero int,
	@IdTipoContacto int
	,@DescError	varchar(1000) ='' OUTPUT
AS
BEGIN
SELECT cc.Contac_Numero AS contactNumero, cc.Cliente_Numero AS clienteNumero, cn.Contac_Nombre AS contacNombre,
       cn.Contac_RutContacto AS contacRutContacto, tc.descripcion, cc.Contac_Telefono1 AS contacTelefono1, cc.Contac_Celular AS contacCelular,
       cc.Contac_Mail AS contacMail, cc.Ciudad_Codigo AS ciudadCodigo
  FROM contactoNew cn INNER JOIN contactoCliente cc ON cc.Contac_Numero = cn.Contac_Numero
INNER JOIN tipoContacto tc ON tc.idTipoContacto = cc.idTipoContacto
WHERE cc.CodTipoNegocio = 2 AND contac_estado = 'Activo' 
AND (@IdEmpresa = 0 OR @IdEmpresa = cc.Cliente_Numero )
AND (@IdTipoContacto = 0 OR @IdTipoContacto = cc.idTipoContacto )
AND (@Contac_Numero = 0 OR @Contac_Numero = cc.Contac_Numero )

	declare	@NumError int = 0
	set	@NumError= @@Error
	if	@NumError<> 0 
		BEGIN
			set @DescError= 'Ocurrió el siguiente Error: (error sql' + Cast(@NumError as varchar(15))+ ')'
			GOTO SALIR
		END
	goto OK

	SALIR:
		set nocount off
	OK:
		return (@NumError)
END
GO


