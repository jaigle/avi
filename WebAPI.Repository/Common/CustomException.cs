using System;
using System.Runtime.Serialization;
using WebAPI.Model;

namespace WebAPI.Repository
{
    [Serializable]
    public class CustomException : Exception
    {
        private Error localError = new Error();
        public CustomException()
        {
        }

        public CustomException(string message) : base(message: message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message: message, innerException: innerException)
        {
        }

        public CustomException(string message, Error localError) 
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info: info, context: context)
        {
        }

        public Error LocalError { get => localError; set => localError = value; }
    }
}