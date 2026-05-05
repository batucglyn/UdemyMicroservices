using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UdemyMicroservices.Discount.Api.Repositories;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Discount.Api.Features.Discounts.GetDiscountByCode
{
    public class GetDiscountByCodeQueryHandler(AppDbContext context)
      : IRequestHandler<GetDiscountByCodeQuery, ServiceResult<GetDiscountByCodeQueryResponse>>
    {
        public async Task<ServiceResult<GetDiscountByCodeQueryResponse>> Handle(GetDiscountByCodeQuery request,
            CancellationToken cancellationToken)
        {
            var hasDiscount = await context.Discounts.SingleOrDefaultAsync(x => x.Code == request.Code, cancellationToken);


            if (hasDiscount == null)
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount not found", HttpStatusCode.NotFound);

            if (hasDiscount.Expired < DateTime.Now)
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount is expired",
                    HttpStatusCode.BadRequest);


            return ServiceResult<GetDiscountByCodeQueryResponse>.SuccessOk(
                new GetDiscountByCodeQueryResponse(hasDiscount.Code, hasDiscount.Rate));
        }
    }
}
