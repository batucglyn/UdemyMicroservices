using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Update
{
    public record class UpdateCourseCommand(
         Guid Id,
    string Name,
    string Description,
    decimal Price,
    string? ImageUrl,
    Guid CategoryId) : IRequestByServiceResult;

}
