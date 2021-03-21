using EstoqueAtalaia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAtalaia.Controllers
{
    public class ProductOutputController : Controller
    {
        private readonly Context _context;

        public ProductOutputController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var output = _context.ProductOutputs
                              .Include("Product")
                              .AsNoTracking();

            ViewBag.Qtde = output.Sum(x => x.Qtde);
            return View(await output.ToListAsync());
        }
      
        public ActionResult Create(int id)
        {
            var prouctOut = _context.Products.Find(id);
            var productOutput = new ProductOutput();
            productOutput.ProductId = id;
            productOutput.Product = prouctOut;
            productOutput.DateTime = DateTime.Now;
            return View(productOutput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductOutput productOutput)
        {
            if (ModelState.IsValid)
            {
                productOutput.Id = 0;
                productOutput.DateTime = DateTime.Now;
                productOutput.Product = null;
                var product = _context.Products.Find(productOutput.ProductId);
                if(productOutput.Qtde <= product.Qtde)
                {
                    _context.ProductOutputs.Add(productOutput);
                    await _context.SaveChangesAsync();

                    product.Qtde = product.Qtde - productOutput.Qtde;
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(productOutput);
                }
            }
            else
            {
                return View(productOutput);
            }
        }

        // GET: ProductOutputController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductOutputController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProductOutputController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductOutputController/Delete/5
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
    }
}
