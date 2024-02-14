using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class RentalById : Specification<Rental>
    {
        public RentalById(int id) : base(r => r.Id == id)
        {
        }
    }
}
