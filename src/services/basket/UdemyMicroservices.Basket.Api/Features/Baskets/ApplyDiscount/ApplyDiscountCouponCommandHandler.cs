using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservices.Basket.Api.Const;
using UdemyMicroservices.Basket.Api.Dtos;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.ApplyDiscount
{
    public class ApplyDiscountCouponCommandHandler(IIdentityService identityService, IDistributedCache distributedCache) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {



            var basketCacheKey = string.Format(BasketConst.BasketCachekey, identityService.UserId);

            var basketJson = await distributedCache.GetStringAsync(
                basketCacheKey, cancellationToken);



            if (string.IsNullOrEmpty(basketJson))
            {

                return ServiceResult<BasketDto>.Error(
                    "Basket Not Found",
                    $"Basket not found for user with ID: {identityService.UserId}",
                    System.Net.HttpStatusCode.NotFound);
            }



            var basket = JsonSerializer.Deserialize<Data.Basket>(basketJson);

            if (basket is null||!basket.BasketItems.Any())
            {
                return ServiceResult<BasketDto>.Error(
                    "Basket item not found",
                    $"Basket is empty for user with ID: {identityService.UserId}",
                    System.Net.HttpStatusCode.NotFound);
            }


            basket.ApplyDiscount(request.DiscountRate, request.Coupon);



            basketJson = JsonSerializer.Serialize(basket);

            await distributedCache.SetStringAsync(
                basketCacheKey,
                basketJson,
                cancellationToken);


            return ServiceResult.SuccessAsNoContent();






        }
    }
}
