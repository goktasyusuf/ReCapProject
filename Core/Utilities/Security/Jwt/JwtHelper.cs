using Core.Entities.Concrete;
using Core.Utilities.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; set; }
        private DateTime _accessTokenExpiration;
        private TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(user, _tokenOptions, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token,
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(User user,TokenOptions tokenOptions,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(

                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                expires: _accessTokenExpiration,
                claims: SetClaims(user, operationClaims)
                );

            return jwt;
        }

        public IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());



            return claims;
        }
    }
}
