﻿using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Bussines.Mapping;
using MyProject.Bussines.TokenServices;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.Bussines.CQRS.Categories.Handlers.QueryHandlers;
using MyProject.Bussines.CQRS.Contacts;
using MyProject.Bussines.CQRS.Contacts.Commands.Request;

using MyProject.DataAccess.UnıtOfWorks;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyProject.Bussines.Services;
using MyProject.Bussines.CQRS.Contacts.Validators;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Request;
using MyProject.Bussines.CQRS.Admin.Dashboard.Handlers;

namespace MyProject.Bussines
{
    public class ServicesRegistration
    {
        public static void AddServices(IServiceCollection services)
        {
            
            services.AddScoped<IEntranceRepository, EntranceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IBasketItemService, BasketItemService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IValidator<ContactUsCommandRequest>, CreateContactCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateContactCommandValidator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddMediatR(typeof(GetAllCategoryQueryHandler).Assembly);
            services.AddMediatR(typeof(GetDashboardDataQueryHandler).Assembly);







        }
    }
}
