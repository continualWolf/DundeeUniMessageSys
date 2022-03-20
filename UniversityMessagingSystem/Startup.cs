
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using UniversityMessagingSystem.Data;

namespace UniversityMessagingSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<dbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddControllersWithViews();
        }
    }
}
