using Asp.Versioning.Builder;
using UdemyMicroservices.Discount.Api.Features.Discounts.CreateDiscount;
using UdemyMicroservices.Discount.Api.Features.Discounts.GetDiscountByCode;

namespace UdemyMicroservices.Discount.Api.Features.Discounts
{
    public static class DiscountEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/discounts").WithTags("Discounts").WithApiVersionSet(apiVersionSet)

               .CreateDiscountGroupItemEndpoint()
               .GetDiscountByCodeGroupItemEndpoint();


        }
    }
}
