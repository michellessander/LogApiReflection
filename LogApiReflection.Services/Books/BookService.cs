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

        public Task<int> Insert(Book book)
        {
            // if (ValidateRequestBody(dict))
            // {
            //     var response = await _bookRepository.Insert(dict);
            // }
            return null;
        }

        private static bool ValidateRequestBody(Dictionary<string, string> dict) => dict.ContainsKey("id") && dict.ContainsKey("Titulo") && dict.ContainsKey("NumeroPaginas");
    }
}