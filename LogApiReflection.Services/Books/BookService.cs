using System.Collections.Generic;
using System.Threading.Tasks;
using LogApiReflection.Domain;
using LogApiReflection.Repositories.Books;

namespace LogApiReflection.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll() => _bookRepository.GetAll();

        public Book GetById(int id) => _bookRepository.GetById(id);

        public int Insert(Book book) => _bookRepository.Insert(book);
    }
}