using System.Collections.Generic;
using System.Linq;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LogApiReflection.Repositories
{
    public class OrderRepository : ApplicationDbContext, IOrderRepository
    {
        public OrderRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public IEnumerable<Order> GetAll()
        {
            var orderList = Order.Include(x => x.Books).ThenInclude(x => x.Author);
            return orderList.ToList();
        }

        public Order GetById(int id)
        {
            var order = Order.Include(x => x.Books).FirstOrDefault(x => x.Id.Equals(id));
            return order;
        }

        public int Add(Order order)
        {
            Order.Add(order);
            return SaveChanges();
        }
    }
}