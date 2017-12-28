USE [Avis]
GO

/****** Object:  View [dbo].[cliente_drilo]    Script Date: 12/27/2017 11:24:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*where not (select top 1 ref.Cliente_Numero  from Clientes_Referencias ref with(nolock) where ref.Cliente_Numero=cli.cliente_numero and ref.CodTipoAdjunto='801' and ref.Negoci_Codigo = 3) is null*/
ALTER VIEW [dbo].[cliente_drilo]
AS
SELECT     cli.Cliente_Numero, cli.Cliente_NomRazonSocial, cli.Cliente_Giro, cli.Cliente_Rut, cli.Cliente_Representante, cli.Cliente_DirComercial, cli.Comuna_Codigo, cli.Ciudad_Codigo, cli.Cliente_CodigoPais, 
                      cli.Cliente_CodPostal, cli.Cliente_Telefono, cli.Cliente_Mail, cli.Cliente_Www, ru.DescRubro, cat.DescCateg, cli.Stc_Codigo, fc.CodTipoNegocio, fc.idModoFacturacion, fc.diaFacturacion, fc.diasPago, 
                      CASE WHEN EXISTS
                          (SELECT     TOP 1 ref.Cliente_Numero
                            FROM          Clientes_Referencias ref WITH (nolock)
                            WHERE      ref.Cliente_Numero = cli.cliente_numero AND ref.CodTipoAdjunto = '801' AND ref.Negoci_Codigo = 3) THEN 'SI' ELSE 'NO' END AS OC, CASE WHEN EXISTS
                          (SELECT     TOP 1 ref.Cliente_Numero
                            FROM          Clientes_Referencias ref WITH (nolock)
                            WHERE      ref.Cliente_Numero = cli.cliente_numero AND ref.CodTipoAdjunto = '10000' AND ref.Negoci_Codigo = 3) THEN 'SI' ELSE 'NO' END AS HES, cli.Cliente_DirPostal
FROM         dbo.clientes AS cli WITH (nolock) LEFT OUTER JOIN
                      dbo.ClientesCategoria AS cat WITH (nolock) ON cat.CodCateg = cli.CodCateg LEFT OUTER JOIN
                      dbo.RUBRO AS ru WITH (nolock) ON ru.IdRubro = cli.IdRubro LEFT OUTER JOIN
                      dbo.facturacionCondiciones AS fc WITH (nolock) ON fc.Cliente_Numero = cli.Cliente_Numero AND fc.CodTipoNegocio = 2

GO

