using System.ComponentModel.DataAnnotations;

namespace WEBSITEDIENTHOAI.Models
{
    public class SANPHAM
    {
        [Key]
        public int IDsanpham { get; set; }
        public string? Tensp { get; set; }
        public float? Giasp { get; set; }
        public int? Sluong { get; set; }
    }

}
