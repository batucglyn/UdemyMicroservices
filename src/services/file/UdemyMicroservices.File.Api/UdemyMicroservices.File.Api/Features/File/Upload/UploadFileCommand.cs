using UdemyMicroservices.Shared;

namespace UdemyMicroservices.File.Api.Features.File.Upload;

public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;


