using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Domain.Core.NFes.Exceptions
{
    public class IntegrationException : Exception
    {
        public IntegrationException(string integrationExceptionMessage) : base(integrationExceptionMessage)
        {

        }
    }
}
