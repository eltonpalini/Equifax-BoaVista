using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using Repository;

namespace DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBillingService, BillingService>();
            serviceCollection.AddScoped<ICourseService, CourseService>();
            serviceCollection.AddScoped<IStudentService,StudentService>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }

        public static void RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBillingRepository, BillingRepository>();
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<IUserRepository,UserRepository>();
        }
    }
}
