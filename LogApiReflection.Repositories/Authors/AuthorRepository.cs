using System;
using System.Collections.Generic;
using System.Linq;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories.Authors
{
    public class AuthorRepository : ApplicationDbContext, IAuthorRepository
    {
        public AuthorRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        
        public IEnumerable<Author> GetAll() => Author;

        public Author GetById(Guid id) => Author.FirstOrDefault(x => x.Id.Equals(id));

        public int Add(Author author)
        {
            Author.Add(author);
            return SaveChanges();
        }

        public Author GetByName(string name) => Author.FirstOrDefault(x => x.Name.Equals(name));


    }
}