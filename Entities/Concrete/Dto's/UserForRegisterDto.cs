using Core.Entities.Abstract;

namespace Entities.Concrete.Dto_s
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? About { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NationalityId { get; set; }
        public int Age { get; set; }
    }
}
