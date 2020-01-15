using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Adapters
{
    public class NFeSqlServerRepository : INFeRepository
    {
        private readonly BoltonContext _context;

        public NFeSqlServerRepository(BoltonContext context)
        {
            _context = context;
        }

        public async Task CreateOrUpdateAsync(NFe nfe)
        {
            if (nfe is null)
            {
                throw new ArgumentNullException(nameof(nfe));
            }

            var current = await FindAsync(nfe.AccessKey);

            if(current is null)
            {
                _context.Add(nfe);
                await _context.SaveChangesAsync();
                return;
            }

            _context.Entry(current).CurrentValues.SetValues(nfe);
            await _context.SaveChangesAsync();
        }

        public async Task<NFe> FindAsync(string AccessKey)
        {
            return await _context.NFes.FirstOrDefaultAsync(n => n.AccessKey.Equals(n.AccessKey));
        }
    }
}
