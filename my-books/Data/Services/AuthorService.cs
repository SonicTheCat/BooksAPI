using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorService
    {
        private readonly AppDbContext context;

        public AuthorService(AppDbContext context) => this.context = context;

        public void AddAuthor(AuthorVM author)
        {
            var dbAuthor = new Author
            {
                Name = author.Name
            };

            this.context.Authors.Add(dbAuthor);
            this.context.SaveChanges();
        }
    }
}