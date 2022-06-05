using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WEBSITEDIENTHOAI.Models
{
    public class MAUSAC
    {
        [Key]
        public int IDmausac { get; set; }
        public string? Tenmausac { get; set; }
        public int Soluong { get; set; }
        public List<SelectListItem> IDctsanpham { set; get; }

    }
}
