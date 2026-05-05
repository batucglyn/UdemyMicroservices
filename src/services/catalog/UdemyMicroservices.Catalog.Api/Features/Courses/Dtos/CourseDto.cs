using UdemyMicroservices.Catalog.Api.Features.Categories.Dtos;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Dtos
{
    public  record CourseDto(Guid Id,
    string Name,
    string Description,
    decimal Price,
    string ImageUrl,
    DateTime Created,
    CategoryDto Category,
    FeatureDto Feature);
    
}
