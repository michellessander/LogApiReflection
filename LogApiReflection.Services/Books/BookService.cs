using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using LogApiReflection.Domain;
using LogApiReflection.Repositories.Books;
using LogApiReflection.Services.Authors;

namespace LogApiReflection.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;

        public BookService(IBookRepository bookRepository, IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
        }

        public IEnumerable<Book> GetAll() => _bookRepository.GetAll();

        public Book GetById(Guid id) => _bookRepository.GetById(id);

        public int Add(Book book)
        {
            if (!ValidadeNotExists(book.Title)) return 0;
            if (book.Author != null) AddAuthor(book);
            return _bookRepository.Add(book);

        }

        private void AddAuthor(Book book) => _authorService.Add(book.Author);

        private bool ValidadeNotExists(string title) => _bookRepository.GetByTitle(title) == null;
    }
}