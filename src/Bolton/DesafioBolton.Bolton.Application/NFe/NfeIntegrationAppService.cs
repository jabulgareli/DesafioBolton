using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Application.NFe
{
    public class NfeIntegrationAppService : INfeIntegrationAppService
    {
        private readonly INFeImportService _nFeImportService;
        private readonly ILogger<NfeIntegrationAppService> _logger;

        public NfeIntegrationAppService(INFeImportService nFeImportService,
                                     ILogger<NfeIntegrationAppService> logger)
        {
            _nFeImportService = nFeImportService;
            _logger = logger;
        }

        public async Task Run()
        {
            try
            {
                await _nFeImportService.ExecuteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
