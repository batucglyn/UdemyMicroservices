namespace UdemyMicroservices.Payment.Api.Features.Payment.Create
{
    public record CreatePaymentResponse(Guid? PaymentId, bool Status, string? ErrorMessage);
}
