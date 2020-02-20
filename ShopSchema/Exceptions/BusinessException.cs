using System;

namespace ShopSchema.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get; private set; }

        public BusinessException(string message, string code) : base(message)
        {
            Code = code;
        }

        public BusinessException(string message, string code, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}