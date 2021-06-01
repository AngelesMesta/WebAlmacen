using Almacen.Data;
using Almacen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Almacen.Controllers
{
    public class ESController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ESController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<ES> ListaES = _context.ES;
            return View(ListaES);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ES es)
        {
            if (ModelState.IsValid)
            {
                _context.ES.Add(es);
                _context.SaveChanges();
                TempData["mensaje"] = "El movimiento se ha añadido de manera correcta";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var es = _context.ES.Find(id);
            if (es == null)
            {
                return NotFound();
            }
            return View(es);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ES es)
        {
            if (ModelState.IsValid)
            {
                _context.ES.Update(es);
                _context.SaveChanges();
                TempData["mensaje"] = "El movimiento se ha actualizado de manera correcta";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var es = _context.ES.Find(id);
            if (es == null)
            {
                return NotFound();
            }
            return View(es);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProducto(int? id)
        {
            var pro = _context.ES.Find(id);
            if (pro == null)
            {
                return NotFound();
            }
            _context.ES.Remove(pro);
            _context.SaveChanges();

            TempData["mensaje"] = "El movimiento se ha eliinado de manera correcta";
            return RedirectToAction("Index");

        }
    }
}

