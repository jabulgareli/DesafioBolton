using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Services;
using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using DesafioBolton.Bolton.Infrastructure.Arquivei.Contracts;
using DesafioBolton.Bolton.Infrastructure.Arquivei.Services;
using DesafioBolton.Bolton.Infrastructure.Arquivei.ValueObjects;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.Adapters
{
    public class ArquiveiNFeImportService : INFeImportService
    {
        private IConfiguration _configuration;
        private INFeRepository _nfeRepository;
        private IImportProfileRepository _importProfileRepository;

        public ArquiveiNFeImportService(IConfiguration configuration,
                                        INFeRepository nfeRepository,
                                        IImportProfileRepository importProfileRepository)
        {
            _configuration = configuration;
            _nfeRepository = nfeRepository;
            _importProfileRepository = importProfileRepository;
        }

        public async Task ExecuteAsync()
        {
            var integrationConfiguration = new ImportIntegrationConfiguration(_configuration["Arquivei:Uri"],
                                                                              _configuration["Arquivei:EndPointNFe"]);

            var hasNextPage = true;

            while (hasNextPage)
            {
                var importProfile = await _importProfileRepository.GetCurrentAsync();

                var result = await integrationConfiguration.GetFullNFeUri(importProfile)
                                                           .WithHeader("x-api-id", _configuration["Arquivei:ApiId"])
                                                           .WithHeader("x-api-key", _configuration["Arquivei:ApiKey"])
                                                           .WithHeader("Content-Type", "application/json")
                                                           .AllowHttpStatus("2XX")
                                                           .GetJsonAsync<NFeResponseContract>();

                if (!result.Data.Any())
                    return;

                await ImportReturnedNFes(result);
                await UpdateImportProfile(importProfile, result);

                hasNextPage = result.Count > 0;
            }
        }

        private async Task UpdateImportProfile(ImportProfile importProfile, NFeResponseContract result)
        {
            if (importProfile is null)
            {
                importProfile = ImportProfile.CreateEmpty();
            }

            importProfile.CurrentPage = result.Page.Next;

            await _importProfileRepository.CreateOrUpdateAsync(importProfile);            
        }

        private async Task ImportReturnedNFes(NFeResponseContract result)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            foreach (var nfeBase64 in result.Data)
            {
                var nfe = Base64ToNFeService.FromBase64(nfeBase64.Xml);

                await _nfeRepository.CreateOrUpdateAsync(nfe);
            }
        }
    }
}
