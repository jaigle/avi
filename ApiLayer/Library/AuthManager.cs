using Test.Entities;

namespace ApiLayer.Library
{
    public class AuthManager : BaseManager
    {
        public AuthManager()
        {

        }

        public ResultModel Authenticate(LoginModel loginData)
        {
            try
            {
                if (IsValid(loginData))
                {
                    return new ResultModel()
                    {
                        Result = true,
                        Token = BuildToken(loginData),
                        ErrorMessage = "OK",
                        ErrorCode = 0,
                        Payload = ""
                    };
                }
                else
                    return new ResultModel()
                    {
                        Result = false,
                        Token = string.Empty,
                        ErrorMessage = "Credenciales no válidas!!",
                        ErrorCode = 99,
                        Payload = ""
                    };
            }
            catch (System.Exception e)
            {
                return new ResultModel()
                {
                    Result = false,
                    Token = string.Empty,
                    ErrorMessage = e.Message,
                    ErrorCode = 1,
                    Payload = ""
                };
            }
            
        }
    }
} 