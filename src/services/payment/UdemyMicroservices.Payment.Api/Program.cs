using Microsoft.EntityFrameworkCore;
using UdemyMicroservices.Payment.Api;
using UdemyMicroservices.Payment.Api.Features.Payment;
using UdemyMicroservices.Payment.Api.Repositories;
using UdemyMicroservices.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCommonServiceExt(typeof(PaymentAssembly));

builder.Services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("payment-in-memory-db"); });


builder.Services.AddVersioningExt();

builder.Services.AddOpenApi();

var app = builder.Build();
app.AddPaymentGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.Run();

