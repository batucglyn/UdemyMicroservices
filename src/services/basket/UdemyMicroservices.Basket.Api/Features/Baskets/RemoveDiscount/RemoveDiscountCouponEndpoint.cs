using MediatR;
using UdemyMicroservices.Basket.Api.Features.Baskets.ApplyDiscount;
using UdemyMicroservices.Shared.Extensions;
using UdemyMicroservices.Shared.Filters;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.RemoveDiscount
{
    public static class RemoveDiscountCouponEndpoint
    {

        public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/remove-discount-coupon",
             async (IMediator mediator) =>
                 (await mediator.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
             .WithName("RemoveDiscountCoupon")
             .MapToApiVersion(1, 0);


            return group;
        }

    }
}
