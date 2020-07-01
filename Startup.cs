using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VulcanForge.Models;
using VulcanForge.Data;
using MySql.Data.MySqlClient;

namespace VulcanForge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<VulcanForgeContext>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
            //services.AddTransient<VulcanForgeContext>(_ => new VulcanForgeContext(Configuration.GetConnectionString("Default"));
            //services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));
            services.AddDbContextPool<VulcanForgeContext>(opt => opt.UseMySql(Configuration.GetConnectionString("Default")));
            services.AddControllers();
            services.AddScoped<IVulcanForgeRepo, MockVulcanForgeRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
