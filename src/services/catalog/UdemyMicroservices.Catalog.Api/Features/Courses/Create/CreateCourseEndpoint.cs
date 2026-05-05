using MediatR;
using UdemyMicroservices.Catalog.Api.Features.Categories.Create;
using UdemyMicroservices.Shared.Extensions;
using UdemyMicroservices.Shared.Filters;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Create
{
    public static class CreateCourseEndpoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                    async (CreateCourseCommand command, IMediator mediator) =>
                        (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateCourse")
                 .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

            return group;
        }
    }
}
