using DesafioBolton.Bolton.Cross.IoC.RegisterContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioBolton.Bolton.Cross.IoC
{
    public static class Bootstrap
    {
        public static void RegisterAllServiceS(IServiceCollection services)
        {
            ApplicationRegister.Register(services);
            InfraRegister.Register(services);
        }
    }
}
