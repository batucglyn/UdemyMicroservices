using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.DeleteBasketItem;

public record DeleteBasketItemCommand(Guid Id) : IRequestByServiceResult;



