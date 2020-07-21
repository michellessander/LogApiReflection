using System.Collections.Generic;

namespace LogApiReflection.Repositories.Logs
{
    public interface ILogRepository
    {
        void Add(Domain.Log log);
        IEnumerable<Domain.Log> GetAll();
    }
}