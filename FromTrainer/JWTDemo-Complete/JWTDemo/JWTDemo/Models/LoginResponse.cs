namespace JWTDemo.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public User user { get; set; }
    }
}
