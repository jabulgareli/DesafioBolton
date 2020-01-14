using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Domain.Core.NFes.Exceptions
{
    public class InvalidIntegrationConfigurationException : IntegrationException
    {
        public InvalidIntegrationConfigurationException(string message) : base(message)
        {
        }
    }
}
