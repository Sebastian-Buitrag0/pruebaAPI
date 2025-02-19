namespace pruebaAPI.Models
{
    public class UserRequest
    {
        public required UserData? UserData { set; get; }
        public string? Username { set; get; }
        public string? Password { set; get; }
    }
}