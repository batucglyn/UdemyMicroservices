using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyMicroservices.Catalog.Api.Features.Categories.GetAll;
using UdemyMicroservices.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.GetAll;





public record GetAllCoursesQuery():IRequestByServiceResult<List<CourseDto>>;



public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) :IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses.ToListAsync(cancellationToken);
        var categories = await context.Categories.ToListAsync(cancellationToken);

       foreach (var course in courses)
        {
            course.Category = categories.First(c => c.Id == course.CategoryId);
        }

        var coursesDto = mapper.Map<List<CourseDto>>(courses);
            return ServiceResult<List<CourseDto>>.SuccessOk(coursesDto);
    }
}





public static class GetAllCoursesEndpoint
{
    public static RouteGroupBuilder GetAllCoursesGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/",
                async (IMediator mediator) =>
                    (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
            .WithName("GetAllCourses")
             .MapToApiVersion(1, 0);

        return group;
    }
}

