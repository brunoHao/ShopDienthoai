using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBSITEDIENTHOAI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Models.SANPHAM> SANPHAM { get; set; }
        public DbSet<Models.CTSANPHAM> CTSANPHAM { get; set;}

        public DbSet<Models.GIOHANG> GIOHANG { get; set; }
        public DbSet<Models.HOADON> HOADON { get; set; }

        public DbSet<Models.CTHOADON> CTHOADON { get; set;}
        public DbSet<Models.MAUSAC> MAUSAC { get; set; }


    }
}
