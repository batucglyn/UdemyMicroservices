using FluentValidation;
using UdemyMicroservices.Basket.Api.Features.Baskets.AddBasketItem;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.ApplyDiscount
{
    public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
    {
        public ApplyDiscountCouponCommandValidator()
        {
             
            RuleFor(x => x.Coupon)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(x => x.DiscountRate)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        }
    }
}
