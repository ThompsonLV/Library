namespace Library.Entities
{
    public class Lector: Person
    {
        public Address Address { get; set; } = null!;

        readonly List<Rental> _rentals = new List<Rental>();
        public IReadOnlyCollection<Rental> Rentals => _rentals.AsReadOnly();
    }
}
