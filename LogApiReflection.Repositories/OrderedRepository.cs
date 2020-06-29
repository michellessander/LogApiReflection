using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories
{
    public class OrderedRepository : DbContext, IOrderedRepository
    {
        public OrderedRepository(DbContextOptions<OrderedRepository> options)
            : base(options)
        { }
        
        public DbSet<Ordered> Ordered { get; set; }
        
        public new int SaveChanges() => base.SaveChanges();
        
        
    }
}