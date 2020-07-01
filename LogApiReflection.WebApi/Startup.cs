using LogApiReflection.Repositories;
using LogApiReflection.Repositories.Books;
using LogApiReflection.Services;
using LogApiReflection.Services.Books;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LogApiReflection
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OrderedRepository>(opt => opt.UseInMemoryDatabase("LogApiReflection"));
            services.AddDbContext<BookRepository>(opt => opt.UseInMemoryDatabase("LogApiReflection"));
            services.AddControllers();
            services.AddScoped<IOrderedRepository, OrderedRepository>();
            services.AddScoped<IOrderedService, OrderedService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}