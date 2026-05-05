using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Order.Application.Contracts.Repositories;
using UdemyMicroservices.Order.Application.Dtos;
using UdemyMicroservices.Shared;
using UdemyMicroservices.Shared.Services;

namespace UdemyMicroservices.Order.Application.Features.Order.Get
{
    public class GetOrdersQueryHandler(IIdentityService identityService, IOrderRepository orderRepository, IMapper mapper)
     : IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrdersResponse>>>
    {
        public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetOrderByBuyerId(identityService.UserId);


            var response = orders.Select(o =>
                new GetOrdersResponse(o.Created, o.TotalPrice, mapper.Map<List<OrderItemDto>>(o.OrderItems))).ToList();


            return ServiceResult<List<GetOrdersResponse>>.SuccessOk(response);
        }
    }
}
