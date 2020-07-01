using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories.Books
{
    public class BookRepository : ApplicationDbContext, IBookRepository
    {
        public BookRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public IEnumerable<Book> GetAll() => Book.Include(x => x.Author);

        public Book GetById(int id) => Book.Include(x => x.Author).FirstOrDefault(x => x.Id.Equals(id));
        
        public int Add(Book book)
        {
            Book.Add(book);
            return SaveChanges();
        }

        public Book GetByTitle(string title) => Book.Include(x => x.Author).FirstOrDefault(x => x.Title.Equals(title));
    }
}