namespace my_books.Data.Models
{
    using System.Collections.Generic;

    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Book> Books{ get; set; }
    }
}