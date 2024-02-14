using System.Text.Json.Serialization;

namespace Library.Entities
{
    public class Book: Entity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Nbpages { get; set; }
        public int AuthorId { get; set; }
        public int DomainId { get; set; }
    
        public Author? Author { get; set; } = null!;

        public Domain? Domain { get; set; } = null!;

        readonly List<Rental> _rentals = new List<Rental>();
        public IReadOnlyCollection<Rental> Rentals => _rentals.AsReadOnly();

    }
}
