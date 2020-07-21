using System;
using System.Collections.Generic;
using System.Linq;
using LogApiReflection.Domain;
using LogApiReflection.Repositories;
using LogApiReflection.Services.Books;
using LogApiReflection.Services.Logs;

namespace LogApiReflection.Services.Orders
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookService _bookService;
        private readonly ILogService _logService;
        
        public OrderService(IOrderRepository orderRepository, IBookService bookService, ILogService logService)
        {
            _orderRepository = orderRepository;
            _bookService = bookService;
            _logService = logService;
        }

        public IEnumerable<Order> GetAll() => _orderRepository.GetAll();

        public Order GetById(Guid id) => _orderRepository.GetById(id);

        public int Add(Order order)
        {
            if (order.Books.Any()) AddBook(order);
            var response = _orderRepository.Add(order);
            if (response != 0) _logService.Log(order, "Add");
            return response;
        }

        private void AddBook(Order order)
        {
            foreach (var book in order.Books)
            {
                _bookService.Add(book);
            }
        }
    }
}