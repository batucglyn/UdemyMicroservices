using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.ApplyDiscount
{
    public record ApplyDiscountCouponCommand(string Coupon,float DiscountRate):IRequestByServiceResult;
    
}
