using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangement.Controllers.DatabaseRepository;
using LibraryMangement.Data;
using LibraryMangement.Data.Repository;
using LibraryMangement.Data.Repository.Implementations;
using LibraryMangement.Data.Repository.Interfaces;
using LibraryMangement.MockData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityDbContext = LibraryMangement.Data.IdentityDbContext;

namespace LibraryMangement
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

//            services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("LibraryManagement"));
//            services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryContext"));


            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

            
            const string connectionString = @"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;";
            services.AddDbContext<LibraryDbContext>(options=>options.UseSqlServer(connectionString));


            
            services.AddTransient<ICustomerRepository,CustomerRepository>();
            services.AddTransient<IBookRepository,BookRepository>();
            services.AddTransient<IAuthorRepository,AutherRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

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
