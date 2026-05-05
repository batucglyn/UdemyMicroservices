using Asp.Versioning.Builder;
using UdemyMicroservices.Catalog.Api.Features.Categories.Create;
using UdemyMicroservices.Catalog.Api.Features.Courses.Create;
using UdemyMicroservices.Catalog.Api.Features.Courses.Delete;
using UdemyMicroservices.Catalog.Api.Features.Courses.GetAll;
using UdemyMicroservices.Catalog.Api.Features.Courses.GetAllByUserId;
using UdemyMicroservices.Catalog.Api.Features.Courses.GetById;
using UdemyMicroservices.Catalog.Api.Features.Courses.Update;

namespace UdemyMicroservices.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses").WithApiVersionSet(apiVersionSet)

                .CreateCourseGroupItemEndpoint()
                .GetAllCoursesGroupItemEndpoint()
                .GetByIdCourseyGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseyByIdGroupItemEndpoint()
                .GetByUserIdCourseGroupItemEndpoint();


        }
    }
}
