using System.Text.Json.Serialization;

namespace Library.Entities
{
    public class Domain: Entity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [JsonIgnore]
        public List<Book> Books { get; set; }
       // public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

    }
}
