using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class BookByIdWithAuthorDomainRentals : BookById
    {
        public BookByIdWithAuthorDomainRentals(int id) : base(id)
        {
            AddInclude(b => b.Author);
            AddInclude(b => b.Rentals);
            AddInclude("Rentals.Lector");
            AddInclude(b => b.Domain);
        }
    }
}
