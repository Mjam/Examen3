using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;
namespace WebAppLab
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IAgenciaService, AgenciaService>();
            services.AddTransient<IAlquilerService, AlquilerService>();
            services.AddTransient<ICatalogoCantonService, CatalogoCantonService>();
            services.AddTransient<ICatalogoDistritoService, CatalogoDistritoService>();
            services.AddTransient<ICatalogoProvinciaService, CatalogoProvinciaService>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<IMarcaVehiculoService, MarcaVehiculoService>();
            services.AddTransient<IUsuariosServices, UsuariosServices>();
            services.AddTransient<IVehiculoService, VehiculoService>();

            return services;
        }
    }
}
