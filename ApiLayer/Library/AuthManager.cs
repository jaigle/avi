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
            return new ResultModel()
            {
                Result = true,
                Token = BuildToken(loginData.UserField, loginData.PassField),
                ErrorMessage = "",
                ErrorCode = 0,
                Payload=""
            };
        }
    }
}  //asumiendo que simepre es true