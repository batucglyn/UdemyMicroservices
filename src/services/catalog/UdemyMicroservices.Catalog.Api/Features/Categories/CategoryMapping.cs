using AutoMapper;
using UdemyMicroservices.Catalog.Api.Features.Categories.Dtos;

namespace UdemyMicroservices.Catalog.Api.Features.Categories;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}

