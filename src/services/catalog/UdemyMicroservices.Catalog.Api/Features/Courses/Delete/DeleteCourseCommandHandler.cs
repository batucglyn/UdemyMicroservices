using MediatR;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Delete
{
    public class DeleteCourseCommandHandler(AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult<bool>>
    {
        public async Task<ServiceResult<bool>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course=await context.Courses.FindAsync(new object?[] { request.Id },cancellationToken);
            if (course == null)
            {
                return ServiceResult<bool>.Error($"Course Not Found course id :({request.Id}) ", System.Net.HttpStatusCode.NotFound);
            }
            context.Courses.Remove(course);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResult<bool>.SuccessOk(true);
        }
    }
}
