using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservices.Shared.Extensions;
using UdemyMicroservices.Shared.Filters;

namespace UdemyMicroservices.File.Api.Features.File.Upload
{
    public static class UploadFileCommandEndpoint
    {
        public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                    async (IFormFile file, IMediator mediator) =>
                        (await mediator.Send(new UploadFileCommand(file))).ToGenericResult())
                .WithName("UploadFile")
                 .MapToApiVersion(1, 0)
                 .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError).DisableAntiforgery();



            return group;
        }
    }
}
