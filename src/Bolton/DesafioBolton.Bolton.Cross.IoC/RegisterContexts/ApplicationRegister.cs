using DesafioBolton.Bolton.Application.NFes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Cross.IoC.RegisterContexts
{
    public static class ApplicationRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<INfeAppService, NfeAppService>();
        }
    }
}
