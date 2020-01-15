using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using DesafioBolton.Bolton.Domain.Core.NFes.ValueObjects;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Adapters
{
    public class ImportProfileSqlServerRepository : IImportProfileRepository
    {
        private readonly BoltonContext _context;
        public ImportProfileSqlServerRepository(BoltonContext context)
        {
            _context = context;
        }

        public async Task<ImportProfile> CreateOrUpdateAsync(ImportProfile profile)
        {
            if (profile is null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            var current = await GetCurrentAsync();

            if (current is null)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return profile;
            }

            _context.Entry(current).CurrentValues.SetValues(profile);
            await _context.SaveChangesAsync();
            return current;
        }

        public async Task<ImportProfile> GetCurrentAsync()
        {
            return await _context.ImportProfiles.FirstOrDefaultAsync();
        }
    }
}
