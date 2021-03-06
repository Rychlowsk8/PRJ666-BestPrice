﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BestPrice.Data;
using BestPrice.Models;
using BestPrice.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http;
using Hangfire;
using Hangfire.MySql.Core;
using BestPrice.Controllers;

namespace BestPrice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            GlobalConfiguration.Configuration.UseStorage(
                new MySqlStorage(Configuration.GetConnectionString("BestPriceDatabase")));
            */

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("BestPriceDatabase")));

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

         
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddMvc()
        .AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

            services.AddDbContext<prj666_192a03Context>(options => options.UseMySQL(Configuration.GetConnectionString("BestPriceDatabase")));
            

            services.Configure<AuthMessageSenderOptions>(Configuration);

            
            services.AddDbContext<prj666_192a03Context>(options => options.UseMySql(Configuration.GetConnectionString("BestPriceDatabase")));

            
            //services.AddHangfire(x => x.UseStorage(new MySqlStorage(Configuration.GetConnectionString("BestPriceDatabase"), new MySqlStorageOptions() { TablePrefix = "Custom" })));

            //services.AddHangfireServer();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            /*
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            */

            // Abstract code for core 1.1 to handle any exception from the browser
            /*app.Use(async (context, next) =>
            {
                await next.Invoke();

                //After going down the pipeline check if we 404'd. 
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    await context.Response.WriteAsync("Woops! We 404'd");
                }
            });*/

            //app.UseExceptionHandler("/Home/Error");


            //For Core 2.0
            app.UseStatusCodePagesWithRedirects("/Home/Error/404");

            //For core 2.2
            //app.UseExceptionHandler("/Home/Error");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseHangfireDashboard("/hangfire");

            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.SendEmailForNotifications(), Cron.Minutely);


            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemOne(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemTwo(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemThree(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemFive(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemFour(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemSix(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemSeven(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemEight(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemNine(), Cron.Hourly);
            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforItemTen(), Cron.Hourly);

            //RecurringJob.AddOrUpdate<NotificationsController>(x => x.CheckPriceforAll(), "0 */6 * * *");

            //BackgroundJob.Enqueue<NotificationsController>(x => x.CheckPriceforItemNine());  
        }
    }
    }
