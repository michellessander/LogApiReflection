using System;
using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Services.Orders
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
        int Add(Order order);
    }
}