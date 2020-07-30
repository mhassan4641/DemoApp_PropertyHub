using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EVS370.PropertyHub.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSession( option =>
                {
                    //option.IdleTimeout = TimeSpan.FromMinutes(20);
                    //option.Cookie.Name = "evs370";
                    option.Cookie.IsEssential = true;
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(
                endpoints=> 
                {
                    endpoints.MapControllerRoute(
                        name:  "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                }
            );
        }
    }
}
