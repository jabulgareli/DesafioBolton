using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Services;
using DesafioBolton.Bolton.Infrastructure.Arquivei.Adapters;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Adapters;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Cross.IoC.RegisterContexts
{
    public static class InfraRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<INFeRepository, NFeSqlServerRepository>();
            services.AddScoped<IImportProfileRepository, ImportProfileSqlServerRepository>();
            services.AddScoped<INFeImportService, ArquiveiNFeImportService>();
        }
    }
}
