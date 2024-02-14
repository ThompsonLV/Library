using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class LectorByIdWithRentailsAddress : LectorById
    {
        public LectorByIdWithRentailsAddress(int id) : base(id)
        {
            AddInclude(l => l.Rentals);
            AddInclude("Rentals.Book");
            AddInclude(l => l.Address);
        }
    }
}
