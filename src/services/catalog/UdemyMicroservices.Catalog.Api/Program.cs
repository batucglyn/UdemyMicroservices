using Microsoft.OpenApi;
using UdemyMicroservices.Catalog.Api;
using UdemyMicroservices.Catalog.Api.Features.Categories;
using UdemyMicroservices.Catalog.Api.Features.Courses;
using UdemyMicroservices.Catalog.Api.Options;
using UdemyMicroservices.Catalog.Api.Repositories;
using UdemyMicroservices.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT token giriniz. Örnek: Bearer eyJ...",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
{
    {
        new OpenApiSecuritySchemeReference("Bearer", document),
        new List<string>()
    }
});
});
builder.Services.AddAuthenticationWithAuthorizationExt(builder.Configuration);
builder.Services.AddOptionsExtension();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));
builder.Services.AddVersioningExt();


var app = builder.Build();

app.AddSeedDataExt().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data has been saved successfully");
});




app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthentication();
app.UseAuthorization();


app.Run();

