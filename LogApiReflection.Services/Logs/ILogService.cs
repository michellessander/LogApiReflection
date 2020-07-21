using System.Collections.Generic;

namespace LogApiReflection.Services.Logs
{
    public interface ILogService
    {
        void Log(object obj, string operation);
        IEnumerable<Domain.Log> GetAll();
    }
}