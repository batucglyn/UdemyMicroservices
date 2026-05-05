using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Shared;

namespace UdemyMicroservices.Order.Application.Features.Order.Get
{
    public record GetOrdersQuery : IRequestByServiceResult<List<GetOrdersResponse>>;
}
