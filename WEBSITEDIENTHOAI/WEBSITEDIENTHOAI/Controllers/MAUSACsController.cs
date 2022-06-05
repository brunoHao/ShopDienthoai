
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WEBSITEDIENTHOAI.Models;
using WEBSITEDIENTHOAI.RepositoryDapper;

namespace WEBSITEDIENTHOAI.Controllers
{
    public class MAUSACsController : Controller
    {
        private readonly IGenericRepository _Repo;

        public MAUSACsController(IGenericRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: MAUSACs
        public async Task<IActionResult> Index()
        {
            var result = _Repo.GetAll<MAUSAC>();
            if (result != null)
            {
                return View(result);
            }
            else
                return View();
        }

        // GET: MAUSACs/Details/5
        public async Task<IActionResult> details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mausac = _Repo.Find<MAUSAC>(id.GetValueOrDefault());
            if (mausac == null)
            {
                return NotFound();
            }

            return View(mausac);
        }

        // GET: MAUSACs/Create
        public IActionResult Create()
        {
            var listCtSanpham = new List<CTSANPHAM>();
            var ctsp = _Repo.GetAll<CTSANPHAM>();
            foreach(var item in ctsp)
            {
                listCtSanpham.Add(item);
            }
            ViewBag.ls = listCtSanpham;
            return View();
        }

        // POST: MAUSACs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tenms,Soluong,Idctsp")] MAUSAC mAUSAC)
        {
            if (ModelState.IsValid)
            {

                if (_Repo.Add<MAUSAC>(mAUSAC))
                    return RedirectToAction(nameof(Index));
                else return NoContent();
            }
            return View(mAUSAC);
        }

        // GET: MAUSACs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null )
        //    {
        //        return NotFound();
        //    }

        //    var mAUSAC = _Repo.Find(id.GetValueOrDefault());
        //    if (mAUSAC == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(mAUSAC);
        //}

        // POST: MAUSACs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(int id,  MAUSAC mausac)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_Repo.Update<MAUSAC>(id, mausac))
            {
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: MAUSACs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            _Repo.Remove<MAUSAC>(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }
    }
}
