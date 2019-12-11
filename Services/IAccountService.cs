using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SMART_BIN.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMART_BIN.Services
{
    public interface IAccountService
    {
        Account Authenticate(string username, string password);

        IEnumerable<Account> GetAll();
    }

    public class AccountService : IAccountService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Account> _accounts = new List<Account>
        {
            new Account { Id = 1, FirstName = "SmartBin", LastName = "SUT", Username = "smartbin", Password = "sut" }
        };

        private readonly AppSettings _appSettings;

        public AccountService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Account Authenticate(string username, string password)
        {
            var account = _accounts.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (account == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, account.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            account.Token = tokenHandler.WriteToken(token);

            return account.WithoutPassword();
        }

        public IEnumerable<Account> GetAll()
        {
            return _accounts.WithoutPasswords();
        }
    }
}