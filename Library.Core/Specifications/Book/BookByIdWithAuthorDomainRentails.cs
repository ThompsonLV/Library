using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class BookByIdWithAuthorDomainRentails : BookById
    {
        public BookByIdWithAuthorDomainRentails(int id) : base(id)
        {
            AddInclude(b => b.Author);
            AddInclude(b => b.Rentails);
            AddInclude(b => b.Domain);
        }
    }
}
