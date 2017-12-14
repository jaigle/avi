using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Model
{
    public class Error
    {
        public Error()
        {
            ErrorCode = 0;
            ErrorMessage = string.Empty;
        }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }
}
