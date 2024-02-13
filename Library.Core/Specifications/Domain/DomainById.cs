using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Specifications;

namespace Library.Specifications
{
    public class DomainById : Specification<Domain>
    {
        public DomainById(int id) : base(d => d.Id == id)
        {
        }
    }
}
