using System.ComponentModel.DataAnnotations;

namespace WEBSITEDIENTHOAI.Models
{
    public class GIOHANG
    {
        [Key]
        public int IDgiohang { get; set; }
        public int? IDsanpham { get; set; }
        public string? Tensp { get; set; }
        public int? Sluongdat { get; set; }
    }
}
