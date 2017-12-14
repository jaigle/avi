﻿CREATE PROCEDURE [dbo].[Cliente_Select_GetEmpresa] 
	@ClienteRut varchar(11),
	@NumeroCliente int
AS
BEGIN
SELECT top 1
C.[Cliente_Numero] AS clienteNumero
      ,[Cliente_Rut] AS clienteRut
      ,[Ciudad_Codigo] AS ciudadCodigo
      ,[Cliente_NomRazonSocial] AS clienteNomRazonSocial
      ,[Cliente_Giro] AS clienteGiro
      ,[Cliente_DirComercial] AS clienteDirComercial
      ,[Cliente_DirPostal] AS clienteDirPostal
      ,[Cliente_CodPostal] AS clienteCodPostal
      ,[Cliente_Telefono] AS clienteTelefono
      ,[Cliente_Mail]	 AS clienteMail
      ,[Cliente_Www] AS clienteWww
      ,[Stc_Codigo] AS stcCodigo
      ,[Comuna_Codigo] AS comunaCodigo
      ,[Cliente_CodigoPais] AS clienteCodigoPais
      ,[CodCateg] 
      ,[IdRubro]
      ,[Cliente_Representante] AS clienteRepresentante
      ,F.CodTipoNegocio
      ,F.idModoFacturacion
      ,F.diaFacturacion
      ,F.diasPago
  FROM [clientes] AS C INNER JOIN facturacionCondiciones as F on F.Cliente_Numero = C.Cliente_Numero
  WHERE ((C.Cliente_Rut = @ClienteRut) OR (@ClienteRut = '*')) AND ((@NumeroCliente = 0) OR (C.Cliente_Numero = @NumeroCliente))
END


