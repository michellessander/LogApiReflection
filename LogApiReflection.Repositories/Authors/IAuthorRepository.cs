using System;
using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Repositories.Authors
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetById(Guid id);
        int Add(Author author);
        Author GetByName(string name);
    }
}