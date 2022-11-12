using Business.Abstract;
using Business.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new SuccessDataResult<AccessToken>(accessToken,Messages.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var check = _userService.GetByMail(userForLoginDto.Email);

            if(check==null)
            {
                return new ErrorDataResult<User>(check,Messages.UserNotFound);
            }
            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,check.PasswordHash,check.PasswordSalt))
            {
                return new ErrorDataResult<User>(check,Messages.WrongPassword);
            }
            return new SuccessDataResult<User>(check,Messages.SuccessfullyLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.SuccessfullySignedIn);
        }

        public IResult UserExists(string email)
        {
            var exist = _userService.GetByMail(email);
            if(exist!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
