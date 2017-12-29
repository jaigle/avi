using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Test.Entities;

namespace ApiLayer.Library
{
    public class BaseManager
    {

        public string Usuario { get; set; }
        public string Rol { get; set; }

        public bool IsValid(LoginModel loginData)
        {
            return (String.Equals(loginData.UserField, Properties.Settings.Default.tokenSecUser) &&
                String.Equals(loginData.PassField, Properties.Settings.Default.tokenSecPass));
        }

        public string BuildToken(LoginModel loginData)
        {
            return Tools.Base64Encode(CryptoManager.Encrypt($"{loginData.UserField}|{loginData.PassField}|{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}"));
        }

        public string BuildTokenPlain(string origText)
        {
            long n = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            byte[] stringBytes = Encoding.Unicode.GetBytes(origText);
            string token = n.ToString()+Convert.ToBase64String(stringBytes, 0, stringBytes.Length);
            return token;
        }

        string DecodeString(string encodedText)
        {
            byte[] stringBytes = Convert.FromBase64String(encodedText);
            return Encoding.Unicode.GetString(stringBytes);
        }

        public ResultModel CheckTokenPlain(string token)
        {
            ResultModel resultModel = new ResultModel();
            string format = "yyyyMMddHHmmss";
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                DateTime time = DateTime.ParseExact(token.Substring(0, 14), format, provider);
                string user = DecodeString(token.Substring(14));

                if (String.Equals(user, Properties.Settings.Default.tokenSecUser))
                {
                    if ((DateTime.Now - time).TotalSeconds > Convert.ToDouble(Properties.Settings.Default.tokenTimeToLive))
                        throw new Exception("Token Expired !!!");
                    resultModel.Result = true;
                }
                else {
                    throw new Exception("Token incorrecto !!!");
                }
                resultModel.Payload = String.Empty;
                resultModel.Token = String.Empty;
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