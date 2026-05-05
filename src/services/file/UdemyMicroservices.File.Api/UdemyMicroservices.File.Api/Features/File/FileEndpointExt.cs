using Asp.Versioning.Builder;
using UdemyMicroservices.File.Api.Features.File.Delete;
using UdemyMicroservices.File.Api.Features.File.Upload;

namespace UdemyMicroservices.File.Api.Features.File
{
    public static class FileEndpointExt
    {
        public static void AddFileGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files").WithTags("Files").WithApiVersionSet(apiVersionSet)
                .UploadFileGroupItemEndpoint()
                .DeleteFileGroupItemEndpoint();





        }
    }
}
