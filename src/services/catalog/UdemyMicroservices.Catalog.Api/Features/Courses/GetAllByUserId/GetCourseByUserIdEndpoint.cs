using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyMicroservices.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.GetAllByUserId
{
    public record GetCourseByUserIdQuery(Guid Id) : IRequestByServiceResult<List<CourseDto>>;

    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<GetCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetCourseByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            var courses = await context.Courses.Where(x => x.UserId == request.Id)
                .ToListAsync(cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken);


            foreach (var course in courses) course.Category = categories.First(x => x.Id == course.CategoryId);

            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);
            return ServiceResult<List<CourseDto>>.SuccessOk(coursesAsDto);  
        }
    }

    public static class GetCourseByUserIdEndpoint
    {
        public static RouteGroupBuilder GetByUserIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/user/{userId:guid}",
                    async (IMediator mediator, Guid userId) =>
                        (await mediator.Send(new GetCourseByUserIdQuery(userId))).ToGenericResult())
                .WithName("GetByUserIdCourses")
                 .MapToApiVersion(1, 0);

            return group;
        }
    }
}
