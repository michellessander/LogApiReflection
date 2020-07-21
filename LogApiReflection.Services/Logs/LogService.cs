using System;
using System.Collections.Generic;
using System.Text;
using LogApiReflection.Repositories.Logs;

namespace LogApiReflection.Services.Logs
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(object obj, string operation)
        {
            var type = obj.GetType();

            var builder = new StringBuilder();
            builder.Append("Log:" + type.Name);
            builder.Append(" - Operation: " + operation);
            builder.Append(" - Date: " + DateTime.Now);

            var prop = type.GetProperty("Id");
            builder.Append(" - " + prop?.Name + ": " + prop?.GetValue(obj));
         
            SaveLog(builder.ToString());
        }

        public IEnumerable<Domain.Log> GetAll() => _logRepository.GetAll();

        private void SaveLog(string texto)
        {
            var log = new Domain.Log {Texto = texto};
            _logRepository.Add(log);
        }
    }
}