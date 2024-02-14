using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class RentalListWithBookLector : Specification<Rental>
    {
        public RentalListWithBookLector() : base()
        {
            AddInclude(b => b.Book);
            AddInclude(b => b.Lector);

        }
    }
}
