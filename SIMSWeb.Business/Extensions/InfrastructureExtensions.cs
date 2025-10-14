using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIMSWeb.Data.Context;

namespace SIMSWeb.Business.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SIMSDBContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("SIMSDBConnection")));

            services.AddAuthentication("MyCookieAuth")
             .AddCookie("MyCookieAuth", options =>
             {
                 options.Cookie.Name = "MyAuthCookie";
                 options.LoginPath = "/Login";
                 options.AccessDeniedPath = "/AccessDenied";
                 options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("AdminTeacherOnly", policy =>
                policy.RequireAssertion(context => context.User.IsInRole("Admin")
                || context.User.IsInRole("Teacher")));
            });
        }
    }
}
