﻿using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        int Add(Order order);
    }
}