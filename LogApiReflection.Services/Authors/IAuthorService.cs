using System;
using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Services.Authors
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();
        Author GetById(Guid id);
        int Add(Author author);
    }
}