using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Xiyi_Platform.Entities
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        [NotNull]
        public string? IP { get; set; }
        public string? RequestMethod { get; set; }
        public string? UserAgent { get; set; }
        public string? RequestUrl { get; set; }

        [NotNull, DefaultValue(typeof(DateTime), "")]
        public DateTime Time { get; set; } = DateTime.Now;


    }
}
