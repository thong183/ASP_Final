using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Options;
using App.Reponsitory;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App
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

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultString")));
            services.Configure<PaginOption>(Configuration.GetSection("PaginOption"));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // ----- Phần này để sử dụng Session. Hướng dẫn tại : https://www.c-sharpcorner.com/article/all-about-session-in-asp-net-core/
            services.AddDistributedMemoryCache();
            services.AddSession(p =>
            {
                p.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            // ----- //

            services.AddScoped<IDataReponsitory<BookCategory>, DataReponsitory<BookCategory>>();
            services.AddScoped<IAuthReponsitory, AuthReponsitory>();
            services.AddScoped<IDataReponsitory<Country>, DataReponsitory<Country>>();
            services.AddScoped<IDataReponsitory<City>, DataReponsitory<City>>();
            services.AddScoped<IDataReponsitory<Dictrict>, DataReponsitory<Dictrict>>();
            services.AddScoped<IPaginationReponsitory<BookCategory>, PaginatinReponsitory<BookCategory>>();

            services.AddTransient<BookDataResponsitory, BookDataResponsitory>();

            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
