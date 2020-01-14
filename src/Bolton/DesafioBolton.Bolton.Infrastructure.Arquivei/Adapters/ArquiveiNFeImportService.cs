using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Services;
using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using DesafioBolton.Bolton.Infrastructure.Arquivei.ACL;
using DesafioBolton.Bolton.Infrastructure.Arquivei.Contracts;
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

        public async Task ExecuteAsync()
        {
            var integrationConfiguration = new ImportIntegrationConfiguration(_configuration["Arquivei:Uri"],
                                                                              _configuration["Arquivei:EndPointNFe"]);

            var importProfile = await _importProfileRepository.GetCurrentAsync();


            var result = await integrationConfiguration.GetFullNFeUri(importProfile)
                                                       .AllowHttpStatus("2XX")
                                                       .GetJsonAsync<NFeResponseContract>();

            if (!result.PlainNFes.Any())
                return;

            await ImportReturnedNFes(result);
            await UpdateImportProfile(importProfile, result);
        }

        private async Task UpdateImportProfile(ImportProfile importProfile, NFeResponseContract result)
        {
            if (importProfile is null)
            {
                throw new ArgumentNullException(nameof(importProfile));
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

            var convertedNFes = PlainNFeToNFeAdapter.FromPlainNFes(result.PlainNFes);

            foreach (var nfe in convertedNFes)
            {
                await _nfeRepository.CreateOrUpdateAsync(nfe);
            }
        }
    }
}
