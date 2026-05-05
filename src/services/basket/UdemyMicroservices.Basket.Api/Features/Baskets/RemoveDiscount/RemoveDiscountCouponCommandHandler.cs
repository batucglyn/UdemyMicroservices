using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservices.Basket.Api.Const;
using UdemyMicroservices.Basket.Api.Dtos;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.RemoveDiscount
{
    public class RemoveDiscountCouponCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {

            Guid userId = identityService.UserId;

            var basketCacheKey = string.Format(BasketConst.BasketCachekey, userId);


            var basketJson = await distributedCache.GetStringAsync(
                basketCacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketJson))
            {

                return ServiceResult.Error(
                    "Basket Not Found",
                    $"Basket not found for user with ID: {userId}",
                    System.Net.HttpStatusCode.NotFound);
            }



            var basket = JsonSerializer.Deserialize<Data.Basket>(
                basketJson);


            basket!.RemoveDiscount();


            basketJson = JsonSerializer.Serialize(basket);
            await distributedCache.SetStringAsync(basketCacheKey,basketJson,cancellationToken);
            return ServiceResult.SuccessAsNoContent();






        }
    }
}
