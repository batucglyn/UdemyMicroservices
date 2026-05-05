using FluentValidation;
using UdemyMicroservices.Basket.Api.Features.Baskets.AddBasketItem;

namespace UdemyMicroservices.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public class DeleteBasketItemCommandValidator : AbstractValidator<DeleteBasketItemCommand>
    {
        public DeleteBasketItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
