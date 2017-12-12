namespace Test.Entities
{
    public class ResultModel
    {
        public ResultModel()
        {
            ErrorCode = 0;
            ErrorMessage = string.Empty;
            Payload = string.Empty;
            Result = true;
            Token = string.Empty;
        }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public string Payload { get; set; }
        public bool Result { get; set; }
        public string Token { get; set; }
    }
}