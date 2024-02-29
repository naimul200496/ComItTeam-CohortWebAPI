using FullStackReference.ReferenceRequest.Data;
using FullStackReference.ReferenceRequest.IService;
using FullStackReference.ReferenceRequest.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FullStackReference.ReferenceRequests.IService;
using FullStackReference.ReferenceRequests.Service;


namespace FullStackReference
{
    public class Startup
    {
        public IConfigration Configuration { get; }

        public Startup(IConfigration IConfigration)
        {
            Configuration = Configuration;
        }

        public void Configuration(IServiceCollection services)
        {
            //to include a Database Context service
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IReferenceRequestsRepository, ReferenceRequestsRepository>();
            services.AddScoped<IReferenceRequestsService, ReferenceRequestService>();
        }
    }
}
