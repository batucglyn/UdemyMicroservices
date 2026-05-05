using AutoMapper;
using MediatR;
using UdemyMicroservices.Catalog.Api.Features.Categories.Dtos;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Catalog.Api.Features.Categories.GetById;

public record GetCategoryByIdRequest(Guid Id) : IRequestByServiceResult<CategoryDto>;


public class GetCategoryByIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdRequest, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id,cancellationToken);
        if (category == null)
            return ServiceResult<CategoryDto>.Error("Not Found", $"Category with Id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
        var categoryDto = mapper.Map<CategoryDto>(category);
        return ServiceResult<CategoryDto>.SuccessOk(categoryDto);
    }
}


public static class GetCategoryByIdEndpoint
{
    public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                    (await mediator.Send(new GetCategoryByIdRequest(id))).ToGenericResult())
            .WithName("GetCategoryById")
              .MapToApiVersion(1,0);

        return group;
    }

}

