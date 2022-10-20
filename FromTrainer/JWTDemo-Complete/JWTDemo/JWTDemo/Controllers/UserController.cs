using JWTDemo.Models;
using JWTDemo.Repos;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        IUserRepo _userrepo;
        public UserController(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }



        [HttpPost("Register")]
        public async Task<ActionResult<Register>> Register(Register newUser)
        {
             int result = _userrepo.CreateUser(newUser);

            return Ok(newUser);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(Login newUser)
        {
            User result = _userrepo.LoginUser(newUser);

            if (result == null) return Unauthorized("Invalid Cred");


            var Login = new LoginResponse
            {
                user = result,
                Token = _userrepo.GenerateToken(result)
            };

            return Ok(Login);
        }

    }
}
