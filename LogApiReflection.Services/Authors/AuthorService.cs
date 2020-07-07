using System.Collections.Generic;
using LogApiReflection.Domain;
using LogApiReflection.Repositories.Authors;

namespace LogApiReflection.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        
        
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<Author> GetAll() => _authorRepository.GetAll();

        public Author GetById(int id) => _authorRepository.GetById(id);

        public int Add(Author author) => ValidadeNotExists(author.Name) ? _authorRepository.Add(author) : 0;

        private bool ValidadeNotExists(string name) => _authorRepository.GetByName(name) == null;
    }
}