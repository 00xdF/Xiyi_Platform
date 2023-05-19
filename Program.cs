using Microsoft.EntityFrameworkCore;
using Xiyi_Platform.Entities.Context;
using Xiyi_Platform.Services;
using Xiyi_Platform.UoW;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Xiyi_Platform.Common.Authorize;
using Xiyi_Platform.Filter;
using Xiyi_Platform.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GenerateLoginToken>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddDbContext<DataBaseContext>(ServiceLifetime.Scoped);
//builder.Services.AddDbContext<DataBaseContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
builder.Services.AddAuth(builder.Configuration);

//初始化数据表
using (var db = new DataBaseContext())
{
    //创建数据库表
    db.Database.EnsureCreated();
}

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<UnAutorizeHandle>();
app.UseMiddleware<VisitorRecord>();
app.UseRouting();
//启用认证和授权
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
