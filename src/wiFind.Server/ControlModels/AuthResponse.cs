using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.AuthModels
{
    public class AuthResponse
    {
        public string username { get; set; }
        public string user_role { get; set; }
        public string token { get; set; }

        // TODO: implement function to extract userid from token to use in db for adding new records or editing records based on user_id
        public AuthResponse(string username, string user_role, string token)
        {
            this.username = username;
            this.user_role = user_role;
            this.token = token;
        }
    }
}
