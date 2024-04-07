using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.AuthModels
{
    public class AuthResponse
    {
        public string username { get; set; }
        public string token { get; set; }

        // TODO: implement function to extract userid from token to use in db for adding new records or editing records based on user_id
        public AuthResponse(string username, string token)
        {
            this.username = username;
            this.token = token;
        }
    }
}
