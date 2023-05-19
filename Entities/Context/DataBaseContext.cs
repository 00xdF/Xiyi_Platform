using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Xiyi_Platform.Entities.Context
{
    public class DataBaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Item> Items { get; set; }
     
        public DataBaseContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3CSDKMT\\SQLSERVER2014;uid=sa;pwd=123456;database=Xiyi_DataBase;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}
