using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Services;
using DesafioBolton.Bolton.Infrastructure.Arquivei.Adapters;
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
            services.AddScoped<INFeImportService, ArquiveiNFeImportService>();
        }
    }
}
