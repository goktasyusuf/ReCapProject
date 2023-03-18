using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public byte [] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public string? About { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public string? phoneNumber { get; set; }
        public string? nationalityId { get; set; }
       
        public int FindexScore { get; set; }
    }

}
