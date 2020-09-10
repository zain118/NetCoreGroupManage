using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevAl.Play.GroupManage.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace DevAl.Play.GroupManage.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => { 
            options.EnableEndpointRouting = false;
            });
            services.AddTransient<IGroupServices,GroupService>();
        }
 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) => {
            context.Response.OnStarting(() => {
                context.Response.Headers.Add("PP","Zain");
                return Task.CompletedTask;
            });
                await next.Invoke();
            });
            //app.UseRouting();
            app.UseMvc();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
           
        }
    }
}
