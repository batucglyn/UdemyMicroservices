using MediatR;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Catalog.Api.Features.Courses.Delete
{
    public static class DeleteCourseByIdEndpoint
    {

        public static RouteGroupBuilder DeleteCourseyByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}",
                    async (IMediator mediator, Guid id) =>
                        (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult())
                .WithName("DeleteCourseById")
                 .MapToApiVersion(1, 0); 


            return group;
        }
    }
}
