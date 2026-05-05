using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Order.Application.Dtos
{
    public record OrderItemDto(Guid ProductId, string ProductName, decimal UnitPrice);
}
