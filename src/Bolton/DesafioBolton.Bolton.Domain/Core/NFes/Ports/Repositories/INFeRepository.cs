using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories
{
    public interface INFeRepository
    {
        Task CreateAsync(NFe nfe);
        Task<NFe> FindAsync(string AccessKey);
    }
}
