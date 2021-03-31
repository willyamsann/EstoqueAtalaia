using EstoqueAtalaia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAtalaia.Controllers
{
    public class OrdemDeServicoController : Controller
    {
        private readonly Context _context;

        public OrdemDeServicoController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var os = _context.OrdemDeServicos
                          .AsNoTracking();

            return View(await os.ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdemDeServico os)
        {
            if (ModelState.IsValid)
            {
             
                    _context.Add(os);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

            }
            else
            {
                return View(os);
            }
           
        }

    }
}
