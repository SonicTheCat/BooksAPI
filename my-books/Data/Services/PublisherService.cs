using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublisherService
    {
        private readonly AppDbContext context;

        public PublisherService(AppDbContext context) => this.context = context;

        public void AddPublisher(PublisherVM publisher)
        {
            var dbPublisher = new Publisher
            {
                Name = publisher.Name
            };

            this.context.Publishers.Add(dbPublisher);
            this.context.SaveChanges();
        }
    }
}
