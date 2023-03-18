using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Concrete.Dto_s;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var check = _userService.GetByMail(userForLoginDto.Email);

            if (check == null)
            {
                return new ErrorDataResult<User>(check, "Kullanıcı Bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, check.PasswordHash, check.PasswordSalt))
            {
                return new ErrorDataResult<User>(check, "Şifre Yanlış");
            }
            return new SuccessDataResult<User>(check, "Başarıyla Giriş Yapıldı");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                EMail = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                About = userForRegisterDto.About,
                Age = userForRegisterDto.Age,
                UserName = userForRegisterDto.UserName,
                nationalityId= userForRegisterDto.NationalityId,
                phoneNumber = userForRegisterDto.PhoneNumber
                
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Başarıyla Kayıt Olundu");
        }

        public IResult UserExists(string email)
        {
            var exist = _userService.GetByMail(email);
            if (exist != null)
            {
                return new ErrorResult("Kullanıcı Zaten Mevcut");
            }
            return new SuccessResult();
        }
    }
}
