using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservices.Basket.Api.Const;
using UdemyMicroservices.Basket.Api.Data;
using UdemyMicroservices.Basket.Api.Dtos;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.GetBasket;

public class GetBasketQueryHandler(IDistributedCache distributedCache, IIdentityService identityService,IMapper mapper) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
{
    public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {

        // 1) UserId al
        Guid userId = identityService.UserId;

        var basketCacheKey = string.Format(BasketConst.BasketCachekey, userId);

        // 2) Redis'ten sepeti al
        var basketJson = await distributedCache.GetStringAsync(
            basketCacheKey, cancellationToken);

        if (string.IsNullOrEmpty(basketJson))
        {
            // Sepet bulunamadı
            return ServiceResult<BasketDto>.Error(
                "Basket Not Found",
                $"Basket not found for user with ID: {userId}",
                System.Net.HttpStatusCode.NotFound);
        }


        var basket=JsonSerializer.Deserialize<Data.Basket>(basketJson);
       
        if (basket == null)
        {
            // Sepet bulunamadı
            return ServiceResult<BasketDto>.Error(
                "Basket Not Found",
                $"Basket not found for user with ID: {userId}",
                System.Net.HttpStatusCode.NotFound);
        }
        var basketDto = mapper.Map<BasketDto>(basket);
        // 3) Sepeti döndür
        return ServiceResult<BasketDto>.SuccessOk(basketDto);



    }
}

