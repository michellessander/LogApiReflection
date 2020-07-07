using System;
using System.Collections.Generic;
using System.Text;
using LogApiReflection.Domain;
using LogApiReflection.Repositories;

namespace LogApiReflection.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(object obj)
        {
            var tipo = obj.GetType();

            var builder = new StringBuilder();
            builder.AppendLine("Log do " + tipo.Name);
            builder.AppendLine("Data: " + DateTime.Now);
            
            foreach (var prop in tipo.GetProperties())
            {
                builder.AppendLine(prop.Name + ": " + prop.GetValue(obj));
            }
            SaveLog(builder.ToString());
        }

        public IEnumerable<Log> GetAll() => _logRepository.GetAll();

        private void SaveLog(string texto)
        {
            var log = new Log {Texto = texto};
            _logRepository.Add(log);
        }
    }
}