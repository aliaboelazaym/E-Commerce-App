﻿using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Ecom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection sevices, IConfiguration configuration)
        {

            sevices.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //sevices.AddScoped<ICategoryRepository, CategoryRepository>();
            //sevices.AddScoped<IProductRepository, ProductRepository>();
            sevices.AddScoped<IUnitOfWork, UnitOfWork>();

            //Configurer DB

            sevices.AddDbContext<ApplicationDbContext>(opt => 
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            return sevices;
        }
    }
}
