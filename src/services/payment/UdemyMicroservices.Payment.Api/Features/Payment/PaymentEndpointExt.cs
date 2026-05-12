using Asp.Versioning.Builder;
using UdemyMicroservices.Payment.Api.Features.Payment.Create;
using UdemyMicroservices.Payment.Api.Features.Payment.GetAllPaymentsByUserId;

namespace UdemyMicroservices.Payment.Api.Features.Payment
{
    public static class PaymentEndpointExt
    {
        public static void AddPaymentGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/payments").WithTags("Payments").WithApiVersionSet(apiVersionSet)
                .CreatePaymentGroupItemEndpoint()
                .GetAllPaymentsByUserIdGroupItemEndpoint().RequireAuthorization();
        }
    }
}
