using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class BookById : Specification<Book>
    {
        public BookById(int id) : base(b => b.Id == id)
        {
        }
    }
}
