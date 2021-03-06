using LogApiReflection.Repositories;
using LogApiReflection.Repositories.Ioc;
using LogApiReflection.Services.Ioc;
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