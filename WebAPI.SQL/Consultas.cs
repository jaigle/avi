using System;

namespace WebAPI.SQL
{
    public class Consultas
    {
        public static class SqlText
        {
            #region Contactos

            public static string ContactoNew_SelectPorRut =
                @"SELECT cn.Contac_Numero AS contactNumero, cn.Contac_Nombre AS contacNombre, cn.Contac_RutContacto AS contacRutContacto 
FROM contactoNew cn WHERE cn.Contac_RutContacto = @Rut";

            public static string ContactoNew_SelectPorContactNumber =
                @"SELECT cn.Contac_Numero AS contactNumero, cn.Contac_Nombre AS contacNombre, cn.Contac_RutContacto AS contacRutContacto 
FROM contactoNew cn WHERE cn.Contac_Numero = @Numero";

            public static string ContactoNew_Insert = @"
            INSERT INTO [contactoNew]
           ([Contac_Numero]
           ,[Contac_Nombre]
           ,[Contac_RutContacto])
            OUTPUT INSERTED.[Contac_Numero]
            VALUES
           ((SELECT MAX(cn.Contac_Numero)+1 AS NuevoNumero FROM contactoNew),@Nombre, @Rut)";

            public static string ContactNew_Max = @"SELECT MAX(cn.Contac_Numero)+1 AS NuevoNumero FROM contactoNew cn";

            public static string Contactos_SelectPorEmpresa =
                @"SELECT cc.Contac_Numero AS contactNumero, cc.Cliente_Numero AS clienteNumero, cn.Contac_Nombre AS contacNombre,
       cn.Contac_RutContacto AS contacRutContacto, tc.descripcion, cc.Contac_Telefono1 AS contacTelefono1, cc.Contac_Celular AS contacCelular,
       cc.Contac_Mail AS contacMail, cc.Ciudad_Codigo AS ciudadCodigo
  FROM contactoNew cn INNER JOIN contactoCliente cc ON cc.Contac_Numero = cn.Contac_Numero
INNER JOIN tipoContacto tc ON tc.idTipoContacto = cc.idTipoContacto
WHERE cc.CodTipoNegocio = 2 AND contac_estado = 'Activo' AND (@IdEmpresa = 0 OR @IdEmpresa = cc.Cliente_Numero )";

            public static string ContactoCliente_Insert =
                @"SELECT cc.Contac_Numero AS contactoNumero, cc.Cliente_Numero AS clienteNumero, cc.idTipoContacto, cc.Contac_Telefono1 AS telefono1,
       cc.Contac_Celular AS contacCelular, cc.Contac_Mail AS contacMail, cc.Ciudad_Codigo AS ciudadCodigo
  FROM contactoCliente cc
WHERE cc.Contac_Numero = @ContactNumero
AND cc.Cliente_Numero = @ClienteNumero
AND cc.CodTipoNegocio = 2";

            public static string ContactoCliente_Update = @"UPDATE contactoCliente SET
	idTipoContacto = @TipoContrato,
	Contac_Telefono1 = @Telefono1,
	Contac_Celular = @Celular,
	Contac_Mail = @Mail,
	Ciudad_Codigo = @Ciudad
    WHERE Contac_Numero = @ContactNumero AND Cliente_Numero = @ClienteNumero AND CodTipoNegocio = 2";

            public static string ContactoCliente_Delete = @"UPDATE contactoCliente SET
	Contac_Estado = 'Inactivo'
    WHERE Contac_Numero = @ContactNumero AND Cliente_Numero = @ClienteNumero AND CodTipoNegocio = 2";

            public static string TipoContacto_Select =
                "select tc.idTipoContacto, tc.descripcion from Avis.dbo.TipoContacto tc";

            #endregion

            public static string Comuna_Select =
                    "SELECT Comuna_Codigo AS Id, Comuna_Nombre AS Nombre FROM COMUNAS Com With(Nolock) order by Comuna_Codigo asc";
            public static string Ciudad_Select =
                "select Ciudad_Codigo as ciudadCodigo, Ciudad_Nombre as ciudadNombre from CIUDADES";

            public static string FLota_Select =
                @"select F.Flotas_Patente as flotaPatente, E.EstFlo_Nombre as estFloAltaBaja, 
S.SubCat_NomMarca as subCatNomMarca, S.SubCat_NomModelo as subCatNomModelo, F.Flotas_AnoFabric as flotasAnoFrabic, F.Flotas_UltKiloEntr as flotasUltKiloEntr
from Flota as F inner join ESTADOFLOTA as E on F.Flotas_Estado = E.EstFlo_COdigo
inner join SUBCATEGORIAS as S on F.SubCat_CodMarcaModelo = S.SubCat_CodMarcaModelo
where F.Flotas_Patente = @Patente";

            public static string Taller_Select = @"select IdTaller AS idTaller
,IdSucursal AS idSucursal
,NombreTaller AS nombreTaller
,DireccionTaller AS direccionTaller
,EncargadoTaller AS  encargadoTaller
,FonoTaller AS fonoTaller
,EmailTaller AS emailTaller
 from Taller";

            public static string STCEjecutivos_Select_GetEjecutivos = @"SELECT [Stc_Codigo] AS stcCodigo
      ,[Stc_Nombre] AS sctNombre
      ,[Stc_Telefono] AS sctTelefon
      ,[Stc_Mail] AS sctMail
      ,[Stc_Direccion] AS sctDireccion
      ,[Stc_Ciudad] AS sctCiudad
  FROM [Avis].[dbo].[STCEJECUTIVOS]";
        }
    }
}
