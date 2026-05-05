using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Order.Application.Dtos;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Order.Application.Features.Order.Create
{
    public record CreateOrderCommand(float? DiscountRate, AddressDto Address, PaymentDto Payment, List<OrderItemDto> Items)
    : IRequestByServiceResult;
}
