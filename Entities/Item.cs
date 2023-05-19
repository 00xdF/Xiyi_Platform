using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Xiyi_Platform.Entities
{
    //衣物实体
    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ItemID")]
        public int ItemID { get; set; }
        [NotNull]
        [Column("ItemName")]
        public string? ItemName { get; set; }
        [NotNull]
        [Column("ItemPrice")]
        public int ItemPrice { get; set; }
        [Column("ItemIntroduce")]
        public string? ItemIntroduce { get; set; }
        [Column("ItemImageUrl")]
        public string? ItemImageUrl { get; set; }
        [NotNull]
        [Column("ItemType")]
        public int ItemType { get; set; }
    }
}
