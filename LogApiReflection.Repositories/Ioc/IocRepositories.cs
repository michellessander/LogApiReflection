using LogApiReflection.Repositories.Authors;
using LogApiReflection.Repositories.Books;
using LogApiReflection.Repositories.Logs;
using Microsoft.Extensions.DependencyInjection;

namespace LogApiReflection.Repositories.Ioc
{
    public class IocRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        }
    }
}