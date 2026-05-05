using Asp.Versioning.Builder;
using UdemyMicroservices.Basket.Api.Features.Baskets.AddBasketItem;
using UdemyMicroservices.Basket.Api.Features.Baskets.ApplyDiscount;
using UdemyMicroservices.Basket.Api.Features.Baskets.DeleteBasketItem;
using UdemyMicroservices.Basket.Api.Features.Baskets.GetBasket;
using UdemyMicroservices.Basket.Api.Features.Baskets.RemoveDiscount;

namespace UdemyMicroservices.Basket.Api.Features.Baskets
{
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets").WithApiVersionSet(apiVersionSet)

                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketGroupItemEndpoint()
                .ApplyDiscountCouponGroupItemEndpoint()
                .RemoveDiscountCouponGroupItemEndpoint();
        }
    }
}
