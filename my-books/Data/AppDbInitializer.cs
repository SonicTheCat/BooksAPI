using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(GetBooks());

                    context.SaveChanges();
                }
            }
        }

        private static List<Book> GetBooks()
        {
            var bookOne = new Book()
            {
                Title = "1st book title",
                Description = "1st book description",
                Author = "1st book author",
                IsRead = true,
                DateRead = DateTime.Now,
                Genre = "Drama",
                Rate = 10,
                DateAdded = DateTime.Now.AddDays(-30)
            };

            var bookTwo = new Book()
            {
                Title = "2nd book title",
                Description = "2nd book description",
                Author = "2nd book author",
                Genre = "Love story",
                DateAdded = DateTime.Now.AddDays(-7)
            };

            return new List<Book>() { bookOne, bookTwo };
        }
    }
}