using System;
using System.Collections.Generic;
using LogApiReflection.Domain;
using LogApiReflection.Repositories.Books;
using LogApiReflection.Services.Authors;
using LogApiReflection.Services.Logs;

namespace LogApiReflection.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly ILogService _logService;

        public BookService(IBookRepository bookRepository, IAuthorService authorService, ILogService logService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _logService = logService;
        }

        public IEnumerable<Book> GetAll() => _bookRepository.GetAll();

        public Book GetById(Guid id) => _bookRepository.GetById(id);

        public int Add(Book book)
        {
            if (!ValidadeNotExists(book.Title)) return 0;
            if (book.Author != null) AddAuthor(book);
            var response = _bookRepository.Add(book);
            if (response != 0) _logService.Log(book, "Add");
            return response;
        }

        private void AddAuthor(Book book) => _authorService.Add(book.Author);

        private bool ValidadeNotExists(string title) => _bookRepository.GetByTitle(title) == null;
    }
}