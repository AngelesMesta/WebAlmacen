using Almacen.Data;
using Almacen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Producto> ListaProductos = _context.Producto;
            return View(ListaProductos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if(ModelState.IsValid)
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                TempData["mensaje"] = "El producto se ha añadido de manera correcta";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null||id==0)
            {
                return NotFound();
            }
            var producto = _context.Producto.Find(id);
            if(producto==null)
            {
                return NotFound(); 
            }
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Update(producto);
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
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProducto(int? id)
        {
            var pro = _context.Producto.Find(id);
            if(pro==null)
            {
                return NotFound();
            }
           _context.Producto.Remove(pro);
           _context.SaveChanges();

                TempData["mensaje"] = "El producto se ha eliinado de manera correcta";
                return RedirectToAction("Index");
          
        }
    }
}
