using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UdemyMicroservices.Basket.Api.Const;
using UdemyMicroservices.Basket.Api.Dtos;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.AddBasketItem;

public class AddBasketItemCommandHandler(BasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {


        // 1) Redis'ten sepeti oku
        var userBasket = await basketService.GetOrCreateBasketAsync(cancellationToken);
        
        
        var item = new Data.BasketItem(
          request.CourseId,
          request.CourseName,
          request.ImageUrl,
          request.CoursePrice,
          null);


        // 4) Aynı ürün daha önce eklenmiş mi? (CourseId'ye göre)
        var existingItem = userBasket.BasketItems.FirstOrDefault(x => x.CourseId == request.CourseId);

        // 5) Varsa eskiyi sil
        if (existingItem is not null)
        {
            userBasket.BasketItems.Remove(existingItem);
        }

        // 6) Yeni ürünü ekle
        userBasket.BasketItems.Add(item);

        //Discount varsa uygula
        userBasket.ApplyAvaliableDiscount();

        // 7) Redis'e geri yaz
        await basketService.CreateBasketCacheAsync(userBasket, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}

