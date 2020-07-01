using System.Collections.Generic;
using System.Threading.Tasks;
using LogApiReflection.Domain;

namespace LogApiReflection.Services.Books
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        int Insert(Book book);
    }
}