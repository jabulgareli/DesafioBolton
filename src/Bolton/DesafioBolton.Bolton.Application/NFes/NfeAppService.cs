using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Application.NFes
{
    public class NfeAppService : INfeAppService
    {
        private readonly INFeImportService _nFeImportService;
        private readonly ILogger<NfeAppService> _logger;
        private readonly INFeRepository _nFeRepository;

        public NfeAppService(INFeImportService nFeImportService,
                             ILogger<NfeAppService> logger,
                             INFeRepository nFeRepository)
        {
            _nFeImportService = nFeImportService;
            _logger = logger;
            _nFeRepository = nFeRepository;
        }

        public async Task<NFe> FindNFeByAccessKeyAsync(string accessKey)
        {

            try
            {
                return await _nFeRepository.FindAsync(accessKey);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task RunIntegrationAsync()
        {
            try
            {
                await _nFeImportService.ExecuteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
