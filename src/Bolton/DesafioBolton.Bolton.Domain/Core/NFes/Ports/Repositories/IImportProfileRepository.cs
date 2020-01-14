using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories
{
    public interface IImportProfileRepository
    {
        Task<ImportProfile> GetCurrentAsync();
        Task CreateOrUpdateAsync(ImportProfile profile);
    }
}
