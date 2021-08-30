namespace my_books.Data.Services
{
    using my_books.Data.Models;
    using my_books.Data.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BooksService
    {
        private readonly AppDbContext context;

        public BooksService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Book> GetAllBooks() => this.context.Books.ToList();

        public Book GetBookById(int id)
        {
            var book = this.context.Books.FirstOrDefault(x => x.Id == id);

            return book;
        }

        public void AddBook(BookVM book)
        {
            var dbBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            this.context.Books.Add(dbBook);
            this.context.SaveChanges();
        }

        public Book UpdateBookById(int bookId, BookVM bookVM)
        {
            var bookFromDb = this.context.Books.FirstOrDefault(x => x.Id == bookId);
            if (bookFromDb != null)
            {
                bookFromDb.Title = bookVM.Title;
                bookFromDb.Author = bookVM.Author;
                bookFromDb.Description = bookVM.Description;
                bookFromDb.IsRead = bookVM.IsRead;
                bookFromDb.DateRead = bookVM.IsRead ? bookVM.DateRead : null;
                bookFromDb.Rate = bookVM.IsRead ? bookVM.Rate : null;
                bookFromDb.Genre = bookVM.Genre;
                bookFromDb.CoverUrl = bookVM.CoverUrl;

                this.context.Update(bookFromDb);
                this.context.SaveChanges();
            }

            return bookFromDb;
        }

        public void DeleteBookById(int bookId)
        {
            var bookFromDb = this.context.Books.FirstOrDefault(x => x.Id == bookId);
            if (bookFromDb != null)
            {
                this.context.Books.Remove(bookFromDb);
                this.context.SaveChanges();
            }
        }
    }
}