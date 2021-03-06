﻿using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;


namespace LogApiReflection.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Order> Order { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Log> Log { get; set; }
        
        public new int SaveChanges() => base.SaveChanges();
    }
}