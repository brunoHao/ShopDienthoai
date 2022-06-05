using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WEBSITEDIENTHOAI.Data;
 

namespace WEBSITEDIENTHOAI.Controllers
{
    public class EXPORTEXCELFILE : Controller
    {
        private readonly ApplicationDbContext ctx;
        public EXPORTEXCELFILE (ApplicationDbContext db)
        {
            ctx = db;
        }
        public IActionResult Index()
        {
            var data = ctx.SANPHAM.ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var Sheet = package.Workbook.Worksheets.Add("SANPHAM");
                //đổ dữ liệu vào Sheet
                Sheet.Cells.LoadFromCollection(data, true);
                //save
                package.Save();
            }    
                var filename = $"SANPHAM_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",filename);
        }
    }
}
