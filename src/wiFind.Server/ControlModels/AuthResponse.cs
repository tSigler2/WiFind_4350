using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.AuthModels
{
    public class AuthResponse
    {
        public string? Id { get; set; }
        public string token { get; set; }


        public AuthResponse(User user, string token)
        {
            this.Id = user.user_id;
            this.token = token;
        }
    }
}
