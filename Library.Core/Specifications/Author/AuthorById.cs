using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class AuthorById : Specification<Author>
    {
        public AuthorById(int id) : base(a => a.Id == id)
        {
        }
    }
}
