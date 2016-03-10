﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using EshopMVC.Models;

namespace EshopMVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source = kab.database.windows.net; Initial Catalog = KAB; Integrated Security = False; User ID = Kolumn3; Password = Samal073; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //var connString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog = KAB; Integrated Security = True; Pooling = False";
            //var connString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Customers;Integrated Security=True;Pooling=False";
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CustomerContext>(o =>
                o.UseSqlServer(connString))
                .AddDbContext<ProductContext>(o =>
                o.UseSqlServer(connString))
                .AddDbContext<ShoppingCartContext>(o =>
                o.UseSqlServer(connString));

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
