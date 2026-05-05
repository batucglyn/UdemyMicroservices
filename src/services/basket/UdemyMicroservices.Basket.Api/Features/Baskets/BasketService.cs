using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservices.Basket.Api.Const;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Basket.Api.Features.Baskets;

public class BasketService(IIdentityService identityService, IDistributedCache distributedCache)
{

    private string GetBasketCacheKey() => string.Format(BasketConst.BasketCachekey, identityService.UserId);

    public Task<string?> GetBasketFromCacheAsync(CancellationToken cancellationToken) =>
        distributedCache.GetStringAsync(GetBasketCacheKey(), cancellationToken);



    public async Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);

        await distributedCache.SetStringAsync(
     GetBasketCacheKey(),
     basketAsString,
     new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(7) },
     cancellationToken);



    }

    public async Task<Data.Basket> GetOrCreateBasketAsync(CancellationToken cancellationToken)
    {
        var basketJson = await GetBasketFromCacheAsync(cancellationToken);

        if (string.IsNullOrEmpty(basketJson))
        {
            return new Data.Basket
            {
                UserId = identityService.UserId,
                BasketItems = new List<Data.BasketItem>()
            };
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketJson);

        return basket ?? new Data.Basket
        {
            UserId = identityService.UserId,
            BasketItems = new List<Data.BasketItem>()
        };
    }


}


