using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var exist = await context.Categories.AnyAsync(c => c.Name == request.Name);

            if (exist) { return ServiceResult<CreateCategoryResponse>.Error("Category name already exist.", desc: $"The Category Name'{request.Name}'Already Exist.", HttpStatusCode.BadRequest); }

            var category = new Category { Name = request.Name, Id = NewId.NextSequentialGuid() };
            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);


            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "<empty>");

        }
    }
}
