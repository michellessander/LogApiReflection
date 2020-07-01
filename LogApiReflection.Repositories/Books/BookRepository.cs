using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories.Books
{
    public class BookRepository : DbContext, IBookRepository
    {
        public DbSet<Book> Book { get; set; }

        public IEnumerable<Book> GetAll() => Book.Include(x => x.Author);

        public Book GetById(int id) => Book.Include(x => x.Author).FirstOrDefault(x => x.Id.Equals(id));
        public Task<int> Insert(Book book)
        {
            book = new Book();
            // book.Id = ;
            Book.Add(book);
            return SaveChangesAsync();
        }
    }
}