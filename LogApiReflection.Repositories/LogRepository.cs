using System.Collections.Generic;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories
{
    public class LogRepository : ApplicationDbContext, ILogRepository
    {
        public LogRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public void Add(Log log)
        {
            Log.Add(log);
            SaveChanges();
        }
        public IEnumerable<Log> GetAll() => Log;
    }
}