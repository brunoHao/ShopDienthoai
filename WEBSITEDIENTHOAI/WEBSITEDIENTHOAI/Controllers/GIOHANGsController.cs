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
    public class GIOHANGsController : Controller
    {
        private readonly IGenericRepository _Repo;

        public GIOHANGsController(IGenericRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: GIOHANGs
        public async Task<IActionResult> Index()
        {
            var result = _Repo.GetAll<GIOHANG>();
            if (result != null)
            {
                return View(result);
            }
            else
                return View();
        }

        // GET: GIOHANGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gIOHANG = _Repo.Find<GIOHANG>(id.GetValueOrDefault());
            if (gIOHANG == null)
            {
                return NotFound();
            }

            return View(gIOHANG);
        }

        // GET: GIOHANGs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GIOHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsp,Tensp,Sluongdat")] GIOHANG gIOHANG)
        {
            if (ModelState.IsValid)
            {
                if (_Repo.Add<GIOHANG>(gIOHANG))
                    return RedirectToAction(nameof(Index));
                else return NoContent();
            }
            return View(gIOHANG);
        }

        //GET: GIOHANGs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var gIOHANG = _Repo.Find(id.GetValueOrDefault());
        //    if (gIOHANG == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(gIOHANG);
        //}

        // POST: GIOHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  GIOHANG gIOHANG)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (_Repo.Update<GIOHANG>(id, gIOHANG))
            {
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: GIOHANGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _Repo.Remove<GIOHANG>(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }

     
    }
}
