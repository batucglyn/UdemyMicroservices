using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Categories.Delete;

public class DeleteCategoryCommandHandler(AppDbContext context) : IRequestHandler<DeleteCategoryCommand, ServiceResult<bool>>
{
    public async Task<ServiceResult<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FindAsync(new object?[] { request.Id }, cancellationToken);


        if (category is null)
        {
            return ServiceResult<bool>.Error(
                "Category not found",
                HttpStatusCode.NotFound);
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult<bool>.SuccessOk(true);
    }
}

