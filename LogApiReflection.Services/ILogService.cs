using System.Collections.Generic;
using LogApiReflection.Domain;

namespace LogApiReflection.Services
{
    public interface ILogService
    {
        void Log(object obj, string operation);
        IEnumerable<Log> GetAll();
    }
}