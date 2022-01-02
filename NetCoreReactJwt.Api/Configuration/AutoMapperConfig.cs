using NetCoreReactJwt.BusinessManager.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            //Automapper - Mapeamento
            services.AddAutoMapper(typeof(NewUserMappingProfile), typeof(UpdateUserMappingProfile));
        }
    }
}
