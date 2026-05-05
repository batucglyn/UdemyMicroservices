

using UdemyMicroservices.Discount.Api.Common;

namespace UdemyMicroservices.Discount.Api.Features.Discounts
{
    public class DiscountCoupon:BaseEntity
    {
        public  Guid UserId { get; set; }
        public float Rate { get; set; }
        public string  Code  { get; set; } = default!;

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Expired  { get; set; }
        


    }
}
