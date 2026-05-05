using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Order.Application.Dtos;

namespace UdemyMicroservices.Order.Application.Features.Order.Get
{
    public record GetOrdersResponse(DateTime Created, decimal TotalPrice, List<OrderItemDto> Items);
}
