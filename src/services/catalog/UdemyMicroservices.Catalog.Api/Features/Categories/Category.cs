using UdemyMicroservices.Catalog.Api.Features.Courses;
using UdemyMicroservices.Catalog.Api.Repositories;

namespace UdemyMicroservices.Catalog.Api.Features.Categories
{

    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Course>? Courses { get; set; }
    }
}
