using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dto_s
{
    public class UserForUpdate : IDto
    {
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
    }
}
