using DesafioBolton.Bolton.Domain.Core.NFes.Exceptions;
using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.ValueObjects
{
    public class ImportIntegrationConfiguration
    {
        public string Uri { get; private set; }
        public string EndpointNFe { get; private set; }

        public ImportIntegrationConfiguration(string uri, string endpointNFe)
        {
            if (string.IsNullOrEmpty(uri))
                throw new InvalidIntegrationConfigurationException($"Parameter {nameof(uri)} is null or empty");

            if (string.IsNullOrEmpty(endpointNFe))
                throw new InvalidIntegrationConfigurationException($"Parameter {nameof(endpointNFe)} is null or empty");

            Uri = uri;
            EndpointNFe = endpointNFe;
        }

        public string GetFullNFeUri(ImportProfile importProfile)
        {
            if (importProfile != null && !string.IsNullOrEmpty(importProfile.CurrentPage))
                return importProfile.CurrentPage;

            return Uri + EndpointNFe;
        }
    }
}
