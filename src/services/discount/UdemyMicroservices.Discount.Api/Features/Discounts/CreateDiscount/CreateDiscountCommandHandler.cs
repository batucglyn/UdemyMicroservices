using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UdemyMicroservices.Discount.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Discount.Api.Features.Discounts.CreateDiscount
{
    public class CreateDiscountCommandHandler(AppDbContext context) : IRequestHandler<CreateDiscountCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var hasCodeForUser = await context.Discounts.AnyAsync(
           x => x.UserId.ToString() == request.UserId.ToString() && x.Code == request.Code, cancellationToken);


            if (hasCodeForUser)
                return ServiceResult.Error("Discount code already exists for this user", HttpStatusCode.BadRequest);

            var discount = new DiscountCoupon
            {

                Code = request.Code,
                Rate = request.Rate,
                UserId = request.UserId,
                Expired = request.Expired,
                Created = DateTime.UtcNow


            };

            await context.Discounts.AddAsync(discount, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResult.SuccessAsNoContent();

        }
    }
}
