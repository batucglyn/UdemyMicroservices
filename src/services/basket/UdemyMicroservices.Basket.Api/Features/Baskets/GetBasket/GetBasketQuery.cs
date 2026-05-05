using UdemyMicroservices.Basket.Api.Dtos;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.GetBasket
{
    public record GetBasketQuery:IRequestByServiceResult<BasketDto>;
  

}
