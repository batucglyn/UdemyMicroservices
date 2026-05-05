using Microsoft.Extensions.Options;

namespace UdemyMicroservices.Discount.Api.Options;

public static class OptionsExtension
{

    public static IServiceCollection AddOptionsExtension(this IServiceCollection services)
    {

        services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations()
             .ValidateOnStart();


        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);





        return services;


    }


}

