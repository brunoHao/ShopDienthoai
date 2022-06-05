using System.ComponentModel.DataAnnotations;

namespace WEBSITEDIENTHOAI.Models
{
    public class CTSANPHAM
    {
        [Key]
        public int IDctsanpham { get; set; }
        public int IDsanpham { get; set; }
        public string? Tensp { get; set; }
        public string? ThuongHieu { get; set; }
    }
}
