using Library.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Specifications
{
    public class AdminByUsernamePassword : Specification<Admin>
    {
        public AdminByUsernamePassword(string email, string pwd) : base(a => a.Email == email && a.Password == pwd)
        {
        }
    }
}
