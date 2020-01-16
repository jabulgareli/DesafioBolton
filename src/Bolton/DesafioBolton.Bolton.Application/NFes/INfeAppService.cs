using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;

namespace DesafioBolton.Bolton.Application.NFes
{
    public interface INfeAppService
    {
        Task RunIntegrationAsync();
        Task<NFe> FindNFeByAccessKeyAsync(string accessKey);
    }
}
