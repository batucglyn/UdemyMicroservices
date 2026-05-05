using Microsoft.Extensions.FileProviders;
using UdemyMicroservices.File.Api;
using UdemyMicroservices.File.Api.Features.File;
using UdemyMicroservices.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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



app.Run();


