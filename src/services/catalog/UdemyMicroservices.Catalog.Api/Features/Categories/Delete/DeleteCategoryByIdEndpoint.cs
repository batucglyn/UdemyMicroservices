using MediatR;
using UdemyMicroservices.Catalog.Api.Features.Categories.Create;
using UdemyMicroservices.Shared.Extensions;
using UdemyMicroservices.Shared.Filters;

namespace UdemyMicroservices.Catalog.Api.Features.Categories.Delete;

public static class DeleteCategoryByIdEndpoint
{
    public static RouteGroupBuilder DeleteCategoryByIdGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                    (await mediator.Send(new DeleteCategoryCommand(id))).ToGenericResult())
            .WithName("DeleteCategoryById")
             .MapToApiVersion(1, 0);

        return group;
    }
}
