using AutoMapper;
using MediatR;
using System.Net;
using UdemyMicroservices.Catalog.Api.Features.Categories.Dtos;
using UdemyMicroservices.Catalog.Api.Features.Categories.GetById;
using UdemyMicroservices.Catalog.Api.Features.Courses.Dtos;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.GetById;




public record GetCourseByIdRequest(Guid Id) : IRequestByServiceResult<CourseDto>;




public class GetCourseByIdHandler(AppDbContext context,IMapper mapper) : IRequestHandler<GetCourseByIdRequest, ServiceResult<CourseDto>>
{
    public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
    {
        
        var course = await context.Courses.FindAsync( request.Id , cancellationToken);
        if (course == null)
        {
            return ServiceResult<CourseDto>.Error($"Course Not Found course id :({request.Id}) ", HttpStatusCode.NotFound);
        }


        var category = (await context.Categories.FindAsync(course.CategoryId, cancellationToken))!;
        course.Category = category;

        var courseDto = mapper.Map<CourseDto>(course);
        return ServiceResult<CourseDto>.SuccessOk(courseDto);

    }
}




public static class GetCourseByIdEndpoint
{
    public static RouteGroupBuilder GetByIdCourseyGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                    (await mediator.Send(new GetCourseByIdRequest(id))).ToGenericResult())
            .WithName("GetCourseById")
             .MapToApiVersion(1, 0);

        return group;
    }

}

