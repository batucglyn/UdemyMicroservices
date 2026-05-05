using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Order.Application.Dtos
{
    public record AddressDto(string Province, string District, string Street, string ZipCode, string Line);
}
