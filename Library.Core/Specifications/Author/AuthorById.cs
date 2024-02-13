using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class AuthorById : Specification<Domain>
    {
        public AuthorById(int id) : base(d => d.Id == id)
        {
        }
    }
}
