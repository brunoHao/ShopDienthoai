using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBSITEDIENTHOAI.Data;
using WEBSITEDIENTHOAI.Models;
using WEBSITEDIENTHOAI.RepositoryDapper;

namespace WEBSITEDIENTHOAI.Controllers
{
    public class CTHOADONsController : Controller
    {
        private readonly IGenericRepository _Repo;

        public CTHOADONsController(IGenericRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: CTHOADONs
        public async Task<IActionResult> Index()
        {
            var result = _Repo.GetAll<CTHOADON>();
            if (result != null)
            {
                return View(result);
            }
            else
                return View();
        }

        // GET: CTHOADONs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTHOADON = _Repo.Find<CTHOADON>(id.GetValueOrDefault());
            if (cTHOADON == null)
            {
                return NotFound();
            }

            return View(cTHOADON);
        }

        // GET: CTHOADONs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CTHOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idhoadon,Ngaythanhtoan")] CTHOADON cTHOADON)
        {
            if (ModelState.IsValid)
            {
                if (_Repo.Add<CTHOADON>(cTHOADON))
                    return RedirectToAction(nameof(Index));
                else return NoContent();
            }
            return View(cTHOADON);
        }

        // GET: CTHOADONs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null )
        //    {
        //        return NotFound();
        //    }

        //    var cTHOADON = _Repo.Find(id.GetValueOrDefault());
        //    if (cTHOADON == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cTHOADON);
        //}

        // POST: CTHOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CTHOADON cTHOADON)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_Repo.Update<CTHOADON>(id, cTHOADON))
            {
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: CTHOADONs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _Repo.Remove<CTHOADON>(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }

     
    }
}
