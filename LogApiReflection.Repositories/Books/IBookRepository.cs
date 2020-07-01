using System.Collections.Generic;
using System.Threading.Tasks;
using LogApiReflection.Domain;

namespace LogApiReflection.Repositories.Books
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        int Add(Book book);
    }
}