using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Shared.Options;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Shared.Extensions
{
    public static class AuthenticationExt
    {

        public static IServiceCollection AddAuthenticationWithAuthorizationExt(this IServiceCollection services, IConfiguration configuration)
        {


            var identityOptions = configuration.GetSection(nameof(IdentityOption)).Get<IdentityOption>();


            services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = identityOptions.Address;
                options.Audience = identityOptions.Audience;
                options.RequireHttpsMetadata = false;


                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                };

            });




            services.AddAuthorization();

            return services;
        }

    }
}
