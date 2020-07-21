using LogApiReflection.Services.Authors;
using LogApiReflection.Services.Books;
using LogApiReflection.Services.Logs;
using LogApiReflection.Services.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace LogApiReflection.Services.Ioc
{
    public class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
        
    }
}