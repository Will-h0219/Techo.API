using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Techo.Data.Repository;
using Techo.Data.Repository.Contracts;
using Techo.Models.Mapper;

namespace Techo.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            var assemblyData = AppDomain.CurrentDomain.Load("Techo.Data");
            var assemblyCore = AppDomain.CurrentDomain.Load("Techo.Core");
            var assemblyCoreContracts = AppDomain.CurrentDomain.Load("Techo.Core.Contracts");

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyCore, assemblyCoreContracts })
                .Where(x => x.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces();
            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyCore, assemblyCoreContracts })
                .Where(x => x.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();
        }
    }
}
