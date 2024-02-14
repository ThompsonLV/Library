using Library.Specifications;

namespace Library.Entities
{
    public class Rental : Entity
    {
        public DateTime RentailDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int LectorId { get; set; }
        public int BookId { get; set;}
        public Lector? Lector { get; set; } = null!;
        public Book? Book { get; set; } = null!;
    }
}
