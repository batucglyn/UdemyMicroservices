using FluentValidation;

namespace UdemyMicroservices.Discount.Api.Features.Discounts.CreateDiscount
{
    public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountCommandValidator()
        {


            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .Length(10).WithMessage("{PropertyName} must be  10 characters");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .WithMessage("{PropertyName} must be a valid decimal number with up to two decimal places");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} must be a valid GUID");

            RuleFor(x => x.Expired)
                .GreaterThan(DateTime.UtcNow).WithMessage("{PropertyName} must be a future date");


        }
    }
}
