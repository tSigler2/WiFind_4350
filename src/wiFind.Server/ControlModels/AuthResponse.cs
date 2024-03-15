using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.AuthModels
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string token { get; set; }

        // TODO: implement function to extract userid from token to use in db for adding new records or editing records based on user_id
        public AuthResponse(string id, string token)
        {
            this.Id = id;
            this.token = token;
        }

        //public AuthResponse(string token)
        //{
        //    this.token = token;
        //}
    }
}
