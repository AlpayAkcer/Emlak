using Emlak.BusinessLayer.Abstract;
using Emlak.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.BusinessLayer.Extentions
{
    public static class ServiceLayerExtentions
    {
        public static IServiceCollection ServiceLayerExtention(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<AdvertService, AdvertManager>();
            services.AddScoped<AdvertTypeService, AdvertTypeManager>();
            services.AddScoped<CityService, CityManager>();
            services.AddScoped<DistrictService, DistrictManager>();
            services.AddScoped<GeneralSettingService, GeneralSettingManager>();
            services.AddScoped<ImageService, ImageManager>();
            services.AddScoped<NeightbourhoodService, NeightbourhoodManager>();
            services.AddScoped<SituationService, SituationManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddAutoMapper(assembly);

            //services.AddControllersWithViews()
            //    .AddFluentValidation(opt =>
            //    {
            //        opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
            //        opt.DisableDataAnnotationsValidation = true;
            //        opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            //    });


            return services;
        }
    }
}
