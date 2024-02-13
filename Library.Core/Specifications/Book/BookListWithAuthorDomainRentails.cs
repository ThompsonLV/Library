using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class BookListWithAuthorDomainRentails : Specification<Book>
    {
        public BookListWithAuthorDomainRentails(): base()
        {
            AddInclude("Author");
            AddInclude("Rentails");
            AddInclude("Domain");
        }
    }
}
