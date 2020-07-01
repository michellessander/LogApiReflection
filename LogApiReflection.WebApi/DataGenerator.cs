using System;
using System.Collections.Generic;
using LogApiReflection.Domain;
using LogApiReflection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace LogApiReflection
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new OrderRepository(serviceProvider.GetRequiredService<DbContextOptions<OrderRepository>>());
            if (context.Order.Any())
            {
                return;
            }

            var author1 = new Author {Id = 1, Name = "Gullar Ferreira"};

            var author2 = new Author {Id = 2, Name = "Pedro Alencar"};

            var book1 = new Book
            {
                Id = 1,
                Title = "Mil e uma noites.",
                Category = Category.Drama,
                NumberOfPages = 350,
                Author = author1,
                Value = 47.00
            };

            var book2 = new Book
            {
                Id = 2,
                Title = "Era uma vez",
                Category = Category.Romance,
                NumberOfPages = 235,
                Author = author2,
                Value = 33.00
            };

            var books = new List<Book>(){book1, book2};

            var order = new Order {Id = 1, Books = books};
                
            context.Order.Add(order);
            context.SaveChanges();
        }
    }
}