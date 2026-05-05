using Microsoft.EntityFrameworkCore;
using UdemyMicroservices.Order.Api.Endpoints.Orders;
using UdemyMicroservices.Order.Application;
using UdemyMicroservices.Order.Application.Contracts.Repositories;
using UdemyMicroservices.Order.Application.Contracts.UnitOfWork;
using UdemyMicroservices.Order.Persistence;
using UdemyMicroservices.Order.Persistence.Repositories;
using UdemyMicroservices.Order.Persistence.UnitOfWork;
using UdemyMicroservices.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);






builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCommonServiceExt(typeof(OrderApplicationAssembly));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("OrderDb")));


builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioningExt();

var app = builder.Build();
app.AddOrderGroupEndpointExt(app.AddVersionSetExt());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

