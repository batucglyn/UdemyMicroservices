using Microsoft.OpenApi;
using UdemyMicroservices.Discount.Api;
using UdemyMicroservices.Discount.Api.Features.Discounts;
using UdemyMicroservices.Discount.Api.Options;
using UdemyMicroservices.Discount.Api.Repositories;
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
builder.Services.AddOptionsExtension();
builder.Services.AddDatabaseServiceExt();



builder.Services.AddCommonServiceExt(typeof(DiscountApiAssembly));




builder.Services.AddVersioningExt();









builder.Services.AddOpenApi();

builder.Services.AddAuthenticationWithAuthorizationExt(builder.Configuration);










var app = builder.Build();
app.AddDiscountGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.Run();


