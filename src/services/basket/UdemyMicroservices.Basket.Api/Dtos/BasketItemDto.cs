namespace UdemyMicroservices.Basket.Api.Dtos
{
    public record BasketItemDto(

        Guid CourseId,
        string CourseName,
        decimal Price,
        decimal? PriceByApplyDiscountRate,
        string? ImageUrl


        );

}
