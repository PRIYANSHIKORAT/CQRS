﻿using CleanArchWithCORSandMediator.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchWithCORSandMediator.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg =>
            {
            ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        
            ctg.AddBehavior(typeof(IPipelineBehavior<,> ),typeof(ValidationBehaviour<,>));
            });

            return services;

        }
    }
}
