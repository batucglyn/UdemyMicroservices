using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using UdemyMicroservices.Payment.Api;
using UdemyMicroservices.Payment.Api.Features.Payment;
using UdemyMicroservices.Payment.Api.Repositories;
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


builder.Services.AddCommonServiceExt(typeof(PaymentAssembly));

builder.Services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("payment-in-memory-db"); });

builder.Services.AddAuthenticationWithAuthorizationExt(builder.Configuration);
builder.Services.AddVersioningExt();

builder.Services.AddOpenApi();

var app = builder.Build();
app.AddPaymentGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.Run();

