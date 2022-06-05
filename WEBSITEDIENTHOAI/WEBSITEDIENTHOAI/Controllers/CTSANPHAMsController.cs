using Microsoft.AspNetCore.Mvc;
using WEBSITEDIENTHOAI.Models;
using WEBSITEDIENTHOAI.RepositoryDapper;

namespace WEBSITEDIENTHOAI.Controllers
{
    public class CTSANPHAMsController : Controller
    {
        private readonly IGenericRepository _Repo;

        public CTSANPHAMsController(IGenericRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: CTSANPHAMs
        public async Task<IActionResult> Index()
        {
            var result = _Repo.GetAll<CTSANPHAM>();
            if (result != null)
            {
                return View(result);
            }
            else
                return View();
        }

        // GET: CTSANPHAMs/Details/5
        public async Task<IActionResult> details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ctsanpham = _Repo.Find<CTSANPHAM>(id.GetValueOrDefault());
            if (ctsanpham == null)
            {
                return NotFound();
            }

            return View(ctsanpham);
        }

        // GET: CTSANPHAMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CTSANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsp,Tensp,ThuongHieu")] CTSANPHAM cTSANPHAM)
        {
            if (ModelState.IsValid)
            {
                if (_Repo.Add<CTSANPHAM>(cTSANPHAM))
                    return RedirectToAction(nameof(Index));
                else return NoContent();
            }
            return View(cTSANPHAM);
        }

        // GET: CTSANPHAMs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null )
        //    {
        //        return NotFound();
        //    }

        //    var cTSANPHAM = _Repo.Find(id.GetValueOrDefault());
        //    if (cTSANPHAM == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cTSANPHAM);
        //}

        // POST: CTSANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CTSANPHAM cTSANPHAM)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_Repo.Update<CTSANPHAM>(id, cTSANPHAM))
            {
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        //GET: CTSANPHAMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _Repo.Remove<CTSANPHAM>(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }
    }
}
