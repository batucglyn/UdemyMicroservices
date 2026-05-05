using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Payment.Api.Features.Payment.GetAllPaymentsByUserId
{
    public record GetAllPaymentsByUserIdQuery : IRequestByServiceResult<List<GetAllPaymentsByUserIdResponse>>;
}
