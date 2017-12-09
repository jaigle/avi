using System;
using Test.Entities;

namespace ApiLayer.Library
{
    public class BaseManager
    {
        public BaseManager()
        {
            
        }

        public string Usuario { get; set; }
        public string Rol { get; set; }

        public string BuildToken(string usuario, string rol)
        {
            return Tools.Base64Encode(CryptoManager.Encrypt($"{usuario}|{rol}|{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}"));
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
                resultModel.ErrorMessage = e.Message;
                resultModel.ErrorCode = 0;
                resultModel.Payload = String.Empty;
                resultModel.Result = false;
                resultModel.Token = token;
            }

            return resultModel;
        }
    }
   
}