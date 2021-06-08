using System;

namespace NerdStore.Core.DomainObjects
{
    public class DomainExeption : Exception
    {
        public DomainExeption()
        {
        }

        public DomainExeption(string message) : base(message)
        {
        }

        public DomainExeption(string message, Exception exception) : base(message, exception)
        {
        }
    }
}