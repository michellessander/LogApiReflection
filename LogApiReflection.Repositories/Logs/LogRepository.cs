using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection.Repositories.Logs
{
    public class LogRepository : ApplicationDbContext, ILogRepository
    {
        public LogRepository(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public void Add(Domain.Log log)
        {
            Log.Add(log);
            SaveChanges();
        }
        public IEnumerable<Domain.Log> GetAll() => Log;
    }
}