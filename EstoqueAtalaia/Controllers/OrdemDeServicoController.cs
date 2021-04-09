using EstoqueAtalaia.Models;
using EstoqueAtalaia.ViewModel;
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
            var listKiko = _context.CheckLists
                          .ToList();


            List<string> listCheck = new List<string>();

            foreach(var item in listKiko)
            {
                listCheck.Add(item.Name);
            }
           

            return View( new OrdemDeServicoViewModel() { checks = listCheck });
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdemDeServico os, IEnumerable<string> check)
        {
            if (ModelState.IsValid)
            {
                foreach(var item in check)
                {
                    os.CheckList += item + ",";
                }
                os.DataAbertura = DateTime.Now;
                    _context.Add(os);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");

            }
            else
            {
                return View(os);
            }
           
        }

        public async Task<IActionResult> Ordem(int id)
        {
            var ordem = _context.OrdemDeServicos.Find(id);

            return View(ordem);
        }

    }
}
