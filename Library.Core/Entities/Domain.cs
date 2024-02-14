using System.Text.Json.Serialization;

namespace Library.Entities
{
    public class Domain: Entity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Book> _books = new List<Book>();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    }
}
