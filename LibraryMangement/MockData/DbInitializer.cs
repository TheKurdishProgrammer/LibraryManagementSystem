using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryMangement.Data;
using LibraryMangement.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryMangement.MockData
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            //            applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService();
            //            LibraryDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<LibraryDbContext>();
            //
            //            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            // Add Lender
            using (var scopedService = applicationBuilder.ApplicationServices.CreateScope())
            {

                LibraryDbContext context = scopedService.ServiceProvider.GetService<LibraryDbContext>();
//            var user = new IdentityUser("Miroslav Mikus");
//            await userManager.CreateAsync(user, "%Miro1");

                // Add Index
                var justin = new Customer {CustomerName = "Justin Noon"};

                var willie = new Customer {CustomerName = "Willie Parodi"};

                var leoma = new Customer {CustomerName = "Leoma  Gosse"};

                context.Customers.Add(justin);
                context.Customers.Add(willie);
                context.Customers.Add(leoma);

                // Add Author
                var authorDeMarco = new Auther
                {
                    AutherName = "M J DeMarco",
                    Books = new List<Book>
                    {
                        new Book {BookName = "The Millionaire Fastlane"},
                        new Book {BookName = "Unscripted"}
                    }
                };

                var authorCardone = new Auther
                {
                    AutherName = "Grant Cardone",
                    Books = new List<Book>()
                    {
                        new Book {BookName = "The 10X Rule"},
                        new Book {BookName = "If You're Not First, You're Last"},
                        new Book {BookName = "Sell To Survive"}
                    }
                };

                context.Authers.Add(authorDeMarco);
                context.Authers.Add(authorCardone);

            
                Console.WriteLine(context.SaveChanges());
            }
        }
    }
}
