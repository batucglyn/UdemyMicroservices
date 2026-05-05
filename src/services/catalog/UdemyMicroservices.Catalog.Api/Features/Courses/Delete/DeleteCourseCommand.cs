using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Delete
{
    public record DeleteCourseCommand(Guid Id)
       : IRequestByServiceResult<bool>;
    
}
