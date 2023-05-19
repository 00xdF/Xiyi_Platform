using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Xiyi_Platform.Common.Authorize
{
    //添加jwt用户登录认证
    public static class Auth
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            //添加JWT认证中间件
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //指定是否验证Issuer（JWT的签发者）的有效性，默认为true。
                    ValidateIssuer = false,
                    //指定是否验证Audience（JWT的接收者）的有效性，默认为true。
                    ValidateAudience = false,
                    //指定是否验证签名的有效性，默认为true。
                    ValidateIssuerSigningKey = true,
                    //指定用于验证签名的密钥。这里用的是对称加密算法
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        configuration.GetSection("JWT:Token").Value!)) // appsetting.json中的配置文件
                };
            });
        }
    }
}
