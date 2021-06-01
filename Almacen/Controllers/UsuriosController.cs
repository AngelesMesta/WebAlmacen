using Almacen.Data;
using Almacen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
    public class UsuriosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsuriosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Usuario> ListaUsuario = _context.Usuario;
            return View(ListaUsuario);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                TempData["mensaje"] = "El producto se ha añadido de manera correcta";
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
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                TempData["mensaje"] = "El producto se ha actualizado de manera correcta";
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
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUsuario(int? id)
        {
            var pro = _context.Usuario.Find(id);
            if (pro == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(pro);
            _context.SaveChanges();

            TempData["mensaje"] = "El usuario se ha eliminado de manera correcta";
            return RedirectToAction("Index");

        }
    }
}
