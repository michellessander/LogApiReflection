using System.Collections.Generic;
using System.Linq;
using LogApiReflection.Domain;
using LogApiReflection.Repositories;
using LogApiReflection.Services.Books;

namespace LogApiReflection.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookService _bookService;
        
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll() => _orderRepository.GetAll();

        public Order GetById(int id) => _orderRepository.GetById(id);

        public int Add(Order order)
        {
            if (order.Books.Any())
                foreach (var book in order.Books)
                {
                    _bookService.Add(book);
                }
            
        }
    }
}