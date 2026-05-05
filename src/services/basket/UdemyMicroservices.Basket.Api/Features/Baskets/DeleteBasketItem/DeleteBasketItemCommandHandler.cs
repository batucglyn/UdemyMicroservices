using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservices.Basket.Api.Const;
using UdemyMicroservices.Basket.Api.Data;
using UdemyMicroservices.Basket.Api.Dtos;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {

        public async Task<ServiceResult> Handle(
            DeleteBasketItemCommand request,
            CancellationToken cancellationToken)
        {
            // 1) UserId al
            Guid userId = identityService.UserId;

            var basketCacheKey = string.Format(BasketConst.BasketCachekey, userId);

            // 2) Redis'ten sepeti al
            var basketJson = await distributedCache.GetStringAsync(
                basketCacheKey, cancellationToken);

            if (string.IsNullOrWhiteSpace(basketJson))
            {
                return ServiceResult.Error(
                    "Basket not found",
                    System.Net.HttpStatusCode.NotFound);
            }

            // 3) JSON -> Basket
            var userBasket = JsonSerializer.Deserialize<Data.Basket>(basketJson);

            if (userBasket is null)
            {
                return ServiceResult.Error(
                    "Basket not found",
                    System.Net.HttpStatusCode.NotFound);
            }

            // 4) Silinecek ürünü bul
            var itemToRemove = userBasket.BasketItems
                .FirstOrDefault(x => x.CourseId == request.Id);

            if (itemToRemove is null)
            {
                return ServiceResult.Error(
                    "Basket item not found",
                    System.Net.HttpStatusCode.NotFound);
            }

            // 5) Ürünü sil
            userBasket.BasketItems.Remove(itemToRemove);

        

            // 7) Güncellenmiş sepeti Redis'e yaz
            var updatedJson = JsonSerializer.Serialize(userBasket);
            await distributedCache.SetStringAsync(
                basketCacheKey,
                updatedJson,
                cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
