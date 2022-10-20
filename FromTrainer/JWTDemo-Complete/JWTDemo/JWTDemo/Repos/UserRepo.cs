using JWTDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JWTDemo.Repos
{
    public class UserRepo : IUserRepo
    {

        public ApplicationDbContext _context;
        private readonly SymmetricSecurityKey _key;


        public UserRepo(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public List<User> AllUsers()
        {
            throw new NotImplementedException();
        }

        public int CreateUser(Register user)
        {

            var hmac = new HMACSHA512();

            var newuser = new User
            {
                UserName = user.UserName,
                FullName = user.FullName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key
            };

            _context.User.Add(newuser);

            _context.SaveChanges();

            return 1;

        }

        public User LoginUser(Login loginCred)
        {
            var user = _context.User.SingleOrDefault(x => x.UserName == loginCred.UserName);

            if (user == null) return null;

            var hmac = new HMACSHA512(user.PasswordSalt);

            var newhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginCred.Password));


            for(int i=0; i < newhash.Length; i++)
            {
                if (newhash[i] != user.PasswordHash[i]) return null;
            }

            return user;

        }


        public bool auth(int userId, int ModuleId, int ActionId)
        {
            /*
             * Role of this User is allowed for the action of this module
             * 
             */

            return true;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
