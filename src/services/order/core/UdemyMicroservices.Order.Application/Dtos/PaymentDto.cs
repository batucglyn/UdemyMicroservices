using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Order.Application.Dtos
{
    public record PaymentDto(string CardNumber, string CardHolderName, string Expiration, string Cvc, decimal Amount);
}
