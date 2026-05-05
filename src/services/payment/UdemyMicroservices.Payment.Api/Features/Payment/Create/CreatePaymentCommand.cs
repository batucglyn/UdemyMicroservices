using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Payment.Api.Features.Payment.Create
{
    public record CreatePaymentCommand(
     string OrderCode,
     string CardNumber,
     string CardHolderName,
     string CardExpirationDate,
     string CardSecurityNumber,
     decimal Amount) : IRequestByServiceResult<CreatePaymentResponse>;
}
