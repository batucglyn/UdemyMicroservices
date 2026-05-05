using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Categories.Delete;

public record DeleteCategoryCommand(Guid Id)
   : IRequestByServiceResult<bool>;



