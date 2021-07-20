using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppcore.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;
using ConsoleAppcore.data;
using Microsoft.EntityFrameworkCore;
using ConsoleAppcore.Repository;

namespace ConsoleAppcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
#if DEBUG

            services.AddRazorPages().AddRazorRuntimeCompilation();
                 // for client side validations
                //.AddViewOptions(option =>
                //{
                //    option.HtmlHelperOptions.ClientValidationEnabled = false;
                //});
#endif
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
            //    RequestPath="/MyStaticFiles"
            //}) ;
            app.UseRouting();
            app.UseCors();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello");
            
            //     });
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

        }
    }
}
