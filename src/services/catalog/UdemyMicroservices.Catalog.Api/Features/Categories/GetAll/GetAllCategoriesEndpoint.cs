using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyMicroservices.Catalog.Api.Features.Categories.Create;
using UdemyMicroservices.Catalog.Api.Features.Categories.Dtos;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Catalog.Api.Features.Categories.GetAll;
public class GetAllCategoriesRequest : IRequestByServiceResult<List<CategoryDto>>;

public class GetAllCategoryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoriesRequest, ServiceResult<List<CategoryDto>>>
{
    public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories.ToListAsync(cancellationToken);

         var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            return ServiceResult<List<CategoryDto>>.SuccessOk(categoriesDto);
    }
}
public static class GetAllCategoriesEndpoint
{
    public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/",
                async (IMediator mediator) =>
                    (await mediator.Send(new GetAllCategoriesRequest())).ToGenericResult())
            .WithName("GetAllCategories")
              .MapToApiVersion(1, 0);

        return group;
    }
}

