
using DAL.Contract;
using DAL.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Dependencies
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeStore, EmployeeStore>();

            services.AddDbContext<AssessmentContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=Assessment;Integrated security=True")); // To settings file
        }
    }
}
