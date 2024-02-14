using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class BookListWithAuthorDomainRentals : Specification<Book>
    {
        public BookListWithAuthorDomainRentals(): base()
        {
            AddInclude(b => b.Author);
            AddInclude(b => b.Rentals);
            AddInclude(b => b.Domain);
        }
    }
}
