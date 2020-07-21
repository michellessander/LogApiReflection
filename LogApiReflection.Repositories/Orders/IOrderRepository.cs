using System;
using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
        int Add(Order order);
    }
}