using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class LectorById : Specification<Lector>
    {
        public LectorById(int id) : base(l => l.Id == id)
        {
        }
    }
}
