using EstoqueAtalaia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAtalaia.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        
        {
            var product = _context.Products
                            .Include("Category")
                            .Include("Brand")
                            .AsNoTracking();

            ViewBag.Qtde = product.Sum(x => x.Qtde);
            ViewBag.ValorTotal = product.Sum(x => x.ValorTotal);
            return View(await product.ToListAsync());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            FillCategorycAndBrand();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if(product.Qtde < 0)
                {
                    ViewBag.Message = "Não pode colocar menor que 0";
                    return View(product);
                }
                else
                {
                    product.ValorTotal = (product.Price * product.Qtde);
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = _context.Products.Find(id);

            FillCategorycAndBrand();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Product product)
        {
            if(id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Products.Update(product);
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
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void FillCategorycAndBrand()
        {
            ViewBag.CategoryId = new SelectList
           (
                _context.Categorys.ToList(),
               "Id",
               "Name"
           );

            ViewBag.BrandId = new SelectList(
                _context.Brands.ToList(),
                "Id",
                "Name"
                );


        }
    } 
}
