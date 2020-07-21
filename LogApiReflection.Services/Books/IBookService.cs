using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogApiReflection.Domain;

namespace LogApiReflection.Services.Books
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(Guid id);
        int Add(Book book);
    }
}