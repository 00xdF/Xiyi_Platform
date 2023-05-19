using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Xiyi_Platform.Entities
{
    public class Admin
    {
        [NotNull,Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        [NotNull]
        public string? AdminName { get; set; }
        [NotNull]
        public string? AdminPssword { get; set; }
        [NotNull]
        public string? AdminAuthority { get; set; }
    }
}
