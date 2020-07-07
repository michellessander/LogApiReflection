using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Services.Authors
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        int Add(Author author);
    }
}