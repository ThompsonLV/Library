using System.Text.Json.Serialization;

namespace Library.Entities
{
    public class Author: Person
    {
        public string Grade { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set;}

        //readonly List<Book> _books = new List<Book>();
        //public IReadOnlyCollection<Book> Books => _books.AsReadOnly();
    }
}
