using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using BLL.Validators;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class ServiceExctensions
    {
        public static IServiceCollection AddContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<EventContext>(options => options.UseSqlServer(connection));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IValidator<EventModel>, EventValidator>();

            return services;
        }
    }
}