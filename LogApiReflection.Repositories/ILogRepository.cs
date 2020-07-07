using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Repositories
{
    public interface ILogRepository
    {
        void Add(Log log);
        IEnumerable<Log> GetAll();
    }
}