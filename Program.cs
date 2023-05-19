using Microsoft.EntityFrameworkCore;
using Xiyi_Platform.Entities.Context;
using Xiyi_Platform.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<DataBaseContext>();
//builder.Services.AddDbContext<DataBaseContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
using (var db = new DataBaseContext())
{
    //创建数据库表
    db.Database.EnsureCreated();
}
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
