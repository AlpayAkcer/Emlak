using Emlak.DataAccessLayer.Abstract;
using Emlak.DataAccessLayer.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DataAccessLayer.Extentions
{
    public static class LoadDataLayerExtentions
    {
        public static IServiceCollection LoadDataLayerExtention(this IServiceCollection services)
        {
            services.AddScoped<IAdvertRepository, AdvertRepository>();
            services.AddScoped<IAdvertTypeRepository, AdvertTypeRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IGeneralSettingRepository, GeneralSettingRepository>();
            services.AddScoped<IImagesRepository, ImagesRepository>();
            services.AddScoped<INeighbourhoodRepository, NeighbourhoodRepository>();
            services.AddScoped<ISituationRepository, SituationRepository>();
            return services;
        }
    }
}
