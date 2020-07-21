using System;
using System.Collections.Generic;
using LogApiReflection.Domain;
using LogApiReflection.Repositories.Authors;
using LogApiReflection.Services.Logs;

namespace LogApiReflection.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogService _logService;

        public AuthorService(IAuthorRepository authorRepository, ILogService logService)
        {
            _authorRepository = authorRepository;
            _logService = logService;
        }

        public IEnumerable<Author> GetAll() => _authorRepository.GetAll();

        public Author GetById(Guid id) => _authorRepository.GetById(id);

        public int Add(Author author)
        {
            if (!ValidadeNotExists(author.Name)) return 0;
            var response = _authorRepository.Add(author);
            if (response != 0) _logService.Log(author, "Add");
            return response;
        }

        private bool ValidadeNotExists(string name) => _authorRepository.GetByName(name) == null;
    }
}