using System.ComponentModel.DataAnnotations;

namespace WEBSITEDIENTHOAI.Models
{
    public class HOADON
    {
        [Key]
        public int IDhoadon { get; set; }
        public int? IDgiohang { get; set; }
        public int? Sluongdat { get; set; }
        public float? Tongdonhang { get; set; }
    }
}
