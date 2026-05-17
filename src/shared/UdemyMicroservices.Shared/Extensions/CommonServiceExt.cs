using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Shared.Extensions;

    public static class CommonServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));
            services.AddValidatorsFromAssemblyContaining(assembly);
            services.AddAutoMapper(cfg => { }, assembly);
            services.AddScoped<IIdentityService, IdentityService>();
        return services;
        }
    }