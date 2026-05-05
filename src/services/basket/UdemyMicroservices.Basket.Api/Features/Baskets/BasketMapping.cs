using AutoMapper;

namespace UdemyMicroservices.Basket.Api.Features.Baskets
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Data.Basket, Dtos.BasketDto>().ReverseMap();
            CreateMap<Data.BasketItem, Dtos.BasketItemDto>().ReverseMap();
        }
    }
}
