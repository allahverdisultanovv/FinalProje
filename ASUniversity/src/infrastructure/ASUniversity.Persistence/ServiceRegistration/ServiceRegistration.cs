using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Application.Abstractions.Services;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;
using ASUniversity.Persistence.Implementations.Repositories;
using ASUniversity.Persistence.Implementations.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASUniversity.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                opt =>
                opt.UseSqlServer(configuration.GetConnectionString("default"))
                );
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {

                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = true;

                opt.User.RequireUniqueEmail = true;

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            }


        ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamResultRepository, ExamResultRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IFacultyService, FacultyService>();


            return services;
        }
    }
}
