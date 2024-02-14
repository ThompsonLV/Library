using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public  class AuthorListWhithBooks : Specification<Author>
    {
        public AuthorListWhithBooks() : base()
        {
            AddInclude(b => b.Books);
        }
    }
}