﻿namespace Library.Entities
{
    public class Rentail : Entity
    {
        public DateTime RentailDate { get; set; }
        public DateTime? ReturnDate { get; set;  }

        public Lector? Lector { get; set; } = null!;
        public Book? Book { get; set; } = null!;
    }
}
