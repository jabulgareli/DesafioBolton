using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.Exceptions
{
    public class IntegrationNotConfiguredException : IntegrationException
    {
        public IntegrationNotConfiguredException(string message) : base(message)
        {
        }
    }
}
