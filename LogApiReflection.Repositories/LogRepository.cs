using System.Collections.Generic;
using LogApiReflection.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories
{
    public class LogRepository : ApplicationDbContext, ILogRepository
    {
        protected LogRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public void Add(Log log) => Log.Add(log);
        public IEnumerable<Log> GetAll() => Log;
    }
}