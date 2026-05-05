using UdemyMicroservices.Shared;

namespace UdemyMicroservices.File.Api.Features.File.Delete
{
    public record DeleteFileCommand(string FileName) : IRequestByServiceResult;
}
