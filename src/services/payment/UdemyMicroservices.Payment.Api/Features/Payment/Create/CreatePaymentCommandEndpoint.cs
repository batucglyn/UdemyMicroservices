using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservices.Shared.Extensions;

namespace UdemyMicroservices.Payment.Api.Features.Payment.Create
{
    public static class CreatePaymentCommandEndpoint
    {
        public static RouteGroupBuilder CreatePaymentGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("",
                    async ([FromBody] CreatePaymentCommand createPaymentCommand, IMediator mediator) =>
                    (await mediator.Send(createPaymentCommand)).ToGenericResult())
                .WithName("create")
                .MapToApiVersion(1, 0)
                .Produces(StatusCodes.Status204NoContent)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

            return group;
        }
    }
}
