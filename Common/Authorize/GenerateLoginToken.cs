using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xiyi_Platform.Entities;

namespace Xiyi_Platform.Common.Authorize
{
    public  class GenerateLoginToken
    {
        private readonly IConfiguration configuration;
        public GenerateLoginToken(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        /// <summary>
        /// 给用户添加权限生成对应的Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="auths"></param>
        /// <returns></returns>  
        public string CreateToken(User user,List<String> auths)
        {
            //Payload 数据载体
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
             };
            foreach (var auth in auths)
            {
                claims.Add(new Claim(ClaimTypes.Role, auth));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Token").Value!)); //对此加密
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //加密方式
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2), //过期时间
                signingCredentials: cred //签名凭据
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token); //写入Token
            return jwt; //返回生成的Token
        }
    }
}
