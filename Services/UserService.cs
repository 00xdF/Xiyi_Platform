using Microsoft.EntityFrameworkCore;
using Xiyi_Platform.Entities;
using Xiyi_Platform.Entities.Context;

namespace Xiyi_Platform.Services
{
    public class UserService
    {
        private DataBaseContext context;
        public UserService(DataBaseContext context) {
            this.context = context;
        }
        
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public async void AddUser(User user)
        {
            await context.Users.AddAsync(user);
            context.SaveChanges();
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUserList()
        {
            List<User> users = await context.Users.Select(x => x).ToListAsync();
            return users;
        }

        public async Task<User> GetUserByID(int id)
        {
            User? user = await context.Users.FindAsync(id);
            return user;
        }
    }
}
