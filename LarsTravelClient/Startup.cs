﻿using LarsTravelClient.Commons;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarsTravelClient
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
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Home/Login"; 
            //    options.ReturnUrlParameter = "/Home/Index"; 
            //});
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //})
            //.AddCookie("Cookies", options =>
            //{
            //     options.LoginPath = "/Home/Login";
            //     options.AccessDeniedPath = "/Home/ConfirmEmail"; // Đường dẫn đến trang từ chối truy cập
            //});
            //services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSession();
            services.AddHttpClient();
            services.AddTransient<CallApi>();
            //services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Login}/{action=Login}/{id?}");
            //    //endpoints.MapRazorPages();
            //});
        }
    }
}
