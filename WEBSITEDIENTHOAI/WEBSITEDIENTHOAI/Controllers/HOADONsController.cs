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
    public class HOADONsController : Controller
    {
        private readonly IGenericRepository _Repo;

        public HOADONsController(IGenericRepository Repo)
        {
            _Repo = Repo;
        }

        // GET: HOADONs
        public async Task<IActionResult> Index()
        {
            var result = _Repo.GetAll<HOADON>();
            if (result != null)
            {
                return View(result);
            }
            else
                return View();
        }

        // GET: HOADONs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hOADON = _Repo.Find<HOADON>(id.GetValueOrDefault());
            if (hOADON == null)
            {
                return NotFound();
            }

            return View(hOADON);
        }

        // GET: HOADONs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGiohang,Sluongdat,Tongdonhang")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {

                if (_Repo.Add<HOADON>(hOADON))
                    return RedirectToAction(nameof(Index));
                else return NoContent();
            }
            return View(hOADON);
        }

        // GET: HOADONs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null )
        //    {
        //        return NotFound();
        //    }

        //    var hOADON = _Repo.Find(id.GetValueOrDefault());
        //    if (hOADON == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(hOADON);
        //}

        // POST: HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HOADON hOADON)
        {
             if (id == null)
            {
                return NotFound();
            }
            if (_Repo.Update<HOADON>(id, hOADON))
            {
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: HOADONs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _Repo.Remove<HOADON>(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }

     
    }
}
