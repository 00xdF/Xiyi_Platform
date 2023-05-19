using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Xiyi_Platform.Entities
{
    //订单实体
    public class Order
    {
        [NotNull]
        public int OrderId { get; set; }

        [NotNull,ForeignKey("ID")]
        public User? User { get; set; }
        [NotNull]
        public List<Item>? Items  { get; set; }
        public String? ItemImages { get; set; }

        [NotNull,DefaultValue(typeof(DateTime), "")]
        public DateTime Time { get; set; } = DateTime.Now;
        [NotNull]
        public int Status { get;set; }
    }
}
