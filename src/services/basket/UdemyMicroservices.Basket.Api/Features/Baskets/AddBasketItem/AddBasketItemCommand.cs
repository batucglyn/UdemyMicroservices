using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.AddBasketItem;

    public record AddBasketItemCommand(Guid CourseId,string CourseName,decimal CoursePrice,string? ImageUrl):IRequestByServiceResult;
    

