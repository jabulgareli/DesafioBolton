using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.Exceptions
{
    public class IntegrationException : Exception
    {
        public IntegrationException(string integrationExceptionMessage) : base(integrationExceptionMessage)
        {

        }
    }
}
