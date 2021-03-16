using System;

namespace GFT.OrderApp.Domain.Exceptions
{
    public class OrderAppDomainException : Exception
    {
        public OrderAppDomainException()
        { }

        public OrderAppDomainException(string message)
            : base(message)
        { }

        public OrderAppDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
