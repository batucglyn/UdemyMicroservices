using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Order.Application.Dtos;
using UdemyMicroservices.Order.Domain.Entities;

namespace UdemyMicroservices.Order.Application.Features.Order
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

        }
    }
}
