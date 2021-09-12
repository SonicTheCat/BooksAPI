namespace my_books.Data.Models
{
    using System.Collections.Generic;

    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation Properties
        public ICollection<BookAuthor> Books { get; set; }
    }
}