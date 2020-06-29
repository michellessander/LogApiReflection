using System.Collections.Generic;
using System.Linq;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LogApiReflection.Repositories
{
    public class OrderedRepository : DbContext, IOrderedRepository
    {
        public OrderedRepository(DbContextOptions<OrderedRepository> options)
            : base(options) { }

        public DbSet<Ordered> Ordered { get; set; }

        public new int SaveChanges() => base.SaveChanges();

        public IEnumerable<Ordered> GetAll()
        {
            var orderedList = Ordered.Include(x => x.Books).ThenInclude(x => x.Author);
            return orderedList.ToList();
        }

        public Ordered GetById(int id)
        {
            var ordered = Ordered.Include(x => x.Books).FirstOrDefault(x => x.Id.Equals(id));
            return ordered;
        }
    }
}