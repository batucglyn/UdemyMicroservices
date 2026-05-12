using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi;
using UdemyMicroservices.File.Api;
using UdemyMicroservices.File.Api.Features.File;
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

builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

builder.Services.AddCommonServiceExt(typeof(FileAssembly));




builder.Services.AddVersioningExt();

builder.Services.AddOpenApi();






var app = builder.Build();
app.UseStaticFiles();
app.AddFileGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();


app.Run();


