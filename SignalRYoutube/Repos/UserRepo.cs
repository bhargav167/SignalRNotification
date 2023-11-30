using Microsoft.EntityFrameworkCore;
using SignalRNotification.Data;
using SignalRNotification.Models;

namespace SignalRYoutube.Repos
{
    public class UserRepo
    {
        private readonly ApplicationDBContext dbContext;   

        public UserRepo(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Users> GetUserDetails(string username, string password)
        {
            return await dbContext.Users.FirstOrDefaultAsync(user => user.Username == username && user.Password == password);
        }
    }
}
