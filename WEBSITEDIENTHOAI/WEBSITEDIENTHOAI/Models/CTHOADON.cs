using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITEDIENTHOAI.Models
{
    
    public class CTHOADON
    {
        [Key]
        public int IDcthoadon { get; set; }
        public string? IDhoadon { get; set; }

        public DateTime? Ngaythanhtoan { get; set; }
        public string? Noinhanhang { get; set; }
    }
}
