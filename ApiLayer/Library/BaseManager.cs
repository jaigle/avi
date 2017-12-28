using System;
using Test.Entities;

namespace ApiLayer.Library
{
    public class BaseManager
    {

        public string Usuario { get; set; }
        public string Rol { get; set; }

        public bool IsValid(LoginModel loginData)
        {
            //string st1 = Properties.Settings.Default.tokenSecUser;
            //string st2 = Properties.Settings.Default.tokenSecPass;
            //string rt1 = loginData.UserField;
            //string rt2 = loginData.PassField;
            //if (st1 == rt1)
            //{
            //    if (st2 == rt2)
            //    {
            //        return true;
            //    }

            //    return false;
            //}
            //return false;
            return (String.Equals(loginData.UserField, Properties.Settings.Default.tokenSecUser) &&
                String.Equals(loginData.PassField, Properties.Settings.Default.tokenSecPass));
        }

        public string BuildToken(LoginModel loginData)
        {
            return Tools.Base64Encode(CryptoManager.Encrypt($"{loginData.UserField}|{loginData.PassField}|{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}"));
        }

        public ResultModel CheckToken(string token)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                string descriptedToken = CryptoManager.Decrypt(Tools.Base64Decode(token));
                string[] tokenParts = descriptedToken.Split('|');
                Usuario = tokenParts[0];
                Rol = tokenParts[1];
                DateTime tokenCreationDate = Convert.ToDateTime(tokenParts[2]);
                //Checking Expiration 
                if ((DateTime.Now - tokenCreationDate).TotalMinutes > Convert.ToDouble(Properties.Settings.Default.tokenTimeToLive))
                    throw new Exception("Token Expired !!!");

                resultModel.Payload = String.Empty;
                resultModel.Result = true;
                resultModel.Token = token;

            }
            catch (Exception e)
            {
                resultModel.ErrorMessage = $"Error de chequeo del token de seguridad : {e.Message}";
                resultModel.ErrorCode = 1;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }

            return resultModel;
        }
    }
   
}