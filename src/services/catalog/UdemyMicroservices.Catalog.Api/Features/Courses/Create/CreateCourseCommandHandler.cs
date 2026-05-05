using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {

            var hasCategory = await context.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);

            if (!hasCategory)
            {
                return ServiceResult<Guid>.Error("Category Not Found", $"Category with Id {request.CategoryId} was not found.", System.Net.HttpStatusCode.NotFound);
            }
            var hasCourseSameName = await context.Courses.AnyAsync(c => c.Name == request.Name, cancellationToken);
            if (hasCourseSameName)
            {
                return ServiceResult<Guid>.Error("Course Name Exists", $"Course with Name {request.Name} already exists.", System.Net.HttpStatusCode.BadRequest);
            }


            var newCourse = mapper.Map<Course>(request);
            newCourse.Created = DateTime.UtcNow;
            newCourse.Id = NewId.NextSequentialGuid();
            newCourse.Feature = new Feature
            {
                Duration = 0,
                Rating = 0,
                EducatorFullName = "batuhan caglayan"
            };
            context.Courses.Add(newCourse);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");





        }
    }
}
