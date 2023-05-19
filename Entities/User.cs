using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Xiyi_Platform.Entities
{
    //用户实体
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }
        [NotNull]
        [Column("UserName")]
        public string? UserName { get; set; }
        [NotNull]
        [Column("PassWord")]
        public string? PassWord { get; set; }
        [NotNull]
        [Column("Money")]
        public int Money { get; set; }
        [NotNull]
        [Column("Address")]
        public string? Address { get; set; }
        [NotNull]
        [Column("Phone")]
        public string? Phone { get; set; }
    }
}
