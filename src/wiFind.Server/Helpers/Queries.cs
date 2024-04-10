using wiFind.Server.AuthModels;

namespace wiFind.Server.Helpers
{
    public class Queries
    {
        public static async Task<bool> hasExistingAccount(UserReg newUser, WiFindContext _wiFindContext)
        {
            var existingAcct = from a in _wiFindContext.Set<AccountInfo>()
                               where (a.username == newUser.username || a.email == newUser.email)
                               select a;
            return existingAcct.Any();
        }

        public static async Task<IQueryable<AccountInfo>> getAccountInfoByUsernameOrEmail(AuthRequest request, WiFindContext _wiFindContext)
        {
            var user = from accountLogin in _wiFindContext.Set<AccountInfo>()
                       where (accountLogin.username == request.username || accountLogin.email == request.username)
                       select accountLogin;
            return user;
        }

    }
}
