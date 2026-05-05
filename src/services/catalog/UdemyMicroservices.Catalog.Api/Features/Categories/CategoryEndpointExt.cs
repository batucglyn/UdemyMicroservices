using Asp.Versioning.Builder;
using UdemyMicroservices.Catalog.Api.Features.Categories.Create;
using UdemyMicroservices.Catalog.Api.Features.Categories.Delete;
using UdemyMicroservices.Catalog.Api.Features.Categories.GetAll;
using UdemyMicroservices.Catalog.Api.Features.Categories.GetById;

namespace UdemyMicroservices.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
           .WithApiVersionSet(apiVersionSet)
               .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetByIdCategoryGroupItemEndpoint()
                .DeleteCategoryByIdGroupItemEndpoint();


        }
    }
}
