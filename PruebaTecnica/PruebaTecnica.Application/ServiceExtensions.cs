using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Application.Behaviours;
using PruebaTecnica.Application.Helpers;
using PruebaTecnica.Application.Interfaces;
using PruebaTecnica.Domain.Entities;
using System.Reflection;

namespace PruebaTecnica.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IDataShapeHelper<Position>, DataShapeHelper<Position>>();
            services.AddScoped<IDataShapeHelper<Employee>, DataShapeHelper<Employee>>();
            services.AddScoped<IDataShapeHelper<Author>, DataShapeHelper<Author>>();
            services.AddScoped<IDataShapeHelper<Book>, DataShapeHelper<Book>>();

            services.AddScoped<IModelHelper, ModelHelper>();
            //services.AddScoped<IMockData, MockData>();
        }
    }
}
