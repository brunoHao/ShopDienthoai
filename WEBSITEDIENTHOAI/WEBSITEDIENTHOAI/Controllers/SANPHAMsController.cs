using Microsoft.AspNetCore.Mvc;
using WEBSITEDIENTHOAI.Models;
using WEBSITEDIENTHOAI.RepositoryDapper;

namespace WEBSITEDIENTHOAI.Controllers
{
    public class SANPHAMsController : Controller
    {
        private readonly IGenericRepository _Repo;

        public SANPHAMsController(IGenericRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: SANPHAMs
        public async Task<IActionResult> Index()
        {
            var result = _Repo.GetAll<SANPHAM>();
            if (result != null)
            {
                return View(result);
            }
            else
                return View();
        }

        // GET: SANPHAMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sANPHAM = _Repo.Find<SANPHAM>(id.GetValueOrDefault());
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tensp,Giasp,Sluong")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                if (_Repo.Add<SANPHAM>(sANPHAM))
                    return RedirectToAction(nameof(Index));
                else return NoContent();
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null )
        //    {
        //        return NotFound();
        //    }

        //    var sANPHAM = _Repo.Find(id.GetValueOrDefault());
        //    if (sANPHAM == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(sANPHAM);
        //}

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,SANPHAM sANPHAM)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_Repo.Update<SANPHAM>(id,sANPHAM))
            {
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: SANPHAMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _Repo.Remove<SANPHAM>(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }
    }
}
