using AutoMapper;
using MediatR;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandHandler(AppDbContext context)
    : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(new object?[] { request.Id }, cancellationToken);
            if (course is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            course.Name = request.Name;
            course.Description = request.Description;
            course.Price = request.Price;
            course.ImageUrl = request.ImageUrl;
            course.CategoryId = request.CategoryId;

            context.Update(course);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
