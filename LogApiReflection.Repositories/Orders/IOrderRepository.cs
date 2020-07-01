using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
    }
}