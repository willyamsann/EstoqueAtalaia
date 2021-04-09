using EstoqueAtalaia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAtalaia.Controllers
{
    public class BrandController : Controller
    {
        private readonly Context _context;

        public BrandController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()

        {
            var product = _context.Brands
                            .AsNoTracking();

            return View(await product.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
             
                    _context.Brands.Add(brand);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

            }
            else
            {
                return View(brand);
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = _context.Brands.Find(id);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Brand product)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Brands.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(product);
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                      Brand brand = _context.Brands.Find(id);
                     _context.Brands.Remove(brand);
                     _context.SaveChanges();
                    return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
