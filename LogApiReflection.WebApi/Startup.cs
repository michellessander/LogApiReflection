using LogApiReflection.Repositories;
using LogApiReflection.Repositories.Authors;
using LogApiReflection.Repositories.Books;
using LogApiReflection.Repositories.Ioc;
using LogApiReflection.Repositories.Logs;
using LogApiReflection.Services;
using LogApiReflection.Services.Authors;
using LogApiReflection.Services.Books;
using LogApiReflection.Services.Ioc;
using LogApiReflection.Services.Logs;
using LogApiReflection.Services.Orders;
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
            IocRepositories.Register(services);
            IocServices.Register(services);
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("LogApiReflection"));
            services.AddControllers();

        }
    }
}