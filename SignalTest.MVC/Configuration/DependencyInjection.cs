using System;
using Microsoft.Extensions.DependencyInjection;
using SignalTest.Application.Services;
using SignalTest.Application.Services.Interfaces;
using SignalTest.Domain.Entities;
using SignalTest.Domain.Interfaces.Notification;
using SignalTest.Domain.Interfaces.Repository;
using SignalTest.Infra.Data;
using SignalTest.Infra.Data.Repository;
using SignalTest.Infra.Notification.NofificationServices;

namespace SignalTest.MVC.Configuration
{
    public static class DependencyInjection
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IUserInstanceRepository, UserRepository>();
            services.AddScoped<ITweetRepository, TweetRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITweetService, TweetService>();
            services.AddScoped<IProcessamentoService, ProcessamentoService>();

            services.AddScoped<IProcessoNotificationService, ProcessoNotificationService>();
            services.AddScoped<ITweetNotificationService, TweetNotificationService>();
            services.AddScoped<IUserNotificationService, UserNotificationService>();
        }

        public static void InjectIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 3;
                })
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAuthentication()
                .Services.ConfigureApplicationCookie(options =>
                {
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromHours(12);
                });
        }
    }

}
