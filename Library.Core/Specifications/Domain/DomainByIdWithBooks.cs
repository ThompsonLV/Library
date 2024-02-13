using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class DomainByIdWithBooks : DomainById
    {
        public DomainByIdWithBooks(int id) : base(id)
        {
            AddInclude(d => d.Books);
        }
    }
}
