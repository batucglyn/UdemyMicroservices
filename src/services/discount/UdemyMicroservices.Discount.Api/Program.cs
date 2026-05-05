using UdemyMicroservices.Discount.Api;
using UdemyMicroservices.Discount.Api.Features.Discounts;
using UdemyMicroservices.Discount.Api.Options;
using UdemyMicroservices.Discount.Api.Repositories;
using UdemyMicroservices.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExtension();
builder.Services.AddDatabaseServiceExt();



builder.Services.AddCommonServiceExt(typeof(DiscountApiAssembly));




builder.Services.AddVersioningExt();









builder.Services.AddOpenApi();












var app = builder.Build();
app.AddDiscountGroupEndpointExt(app.AddVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();


