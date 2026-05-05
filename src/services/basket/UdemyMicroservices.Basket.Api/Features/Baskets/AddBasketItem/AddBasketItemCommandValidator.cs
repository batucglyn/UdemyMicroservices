using FluentValidation;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator() {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(x => x.CoursePrice)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            
        }
    }
}
