using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class RentalByIdWithBookLector : RentalById
    {
        public RentalByIdWithBookLector(int id) : base(id)
        {
            AddInclude(r => r.Book);
            AddInclude(r => r.Lector);
        }
    }
}
