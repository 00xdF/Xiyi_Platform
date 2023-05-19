using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Xiyi_Platform.Common.Authorize;
using Xiyi_Platform.Entities;
using Xiyi_Platform.Entities.Context;
using Xiyi_Platform.UoW;

namespace Xiyi_Platform.Services
{
    public class UserService
    {
        private readonly UnitOfWork uow;
        private readonly GenerateLoginToken _GLT;
        public UserService(GenerateLoginToken GLT,UnitOfWork uow) {
            this.uow = uow;
            _GLT = GLT;
        }
        
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public async void AddUser(User user)
        {
            await uow.DBContext.Users.AddAsync(user);
            uow.Commit();
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUserList()
        {
            List<User> users = await uow.DBContext.Users.Select(x => x).ToListAsync();
            return users;
        }

        /// <summary>
        /// 通过ID查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserByID(int id)
        {
            User? user = await uow.DBContext.Users.FindAsync(id);
            return user;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public string Login(String UserName,String PassWord)
        {
            var res = uow.DBContext.Users.Where(x=>x.UserName.Equals(UserName) && x.PassWord.Equals(PassWord)).ToList();
            if(res.Count == 0)
            {
                return "";
            }
            return _GLT.CreateToken(GetUserByID(res[0].ID).Result, new List<string> { "user"});
           
        }

        /// <summary>
        /// 模糊搜索用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<List<User>> searchUser(string data)
        {
            if (data.IsNullOrEmpty()) {
                return new List<User>();
            }
            var res = await uow.DBContext.Users
                .Where(x => x.UserName.Contains(data)
                || x.Phone.Contains(data)
                || x.Address.Contains(data)).ToListAsync();
            return res;
        }
    }
}
