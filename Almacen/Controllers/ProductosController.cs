using Almacen.Data;
using Almacen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Almacen.Controllers
{
    
    public class ProductosController : Controller
    {
        private readonly AlmacenContext _context;
        private readonly UserManager<IdentityUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        public ProductosController(UserManager<IdentityUser> userManager, AlmacenContext context)
        {
            this.userManager = userManager;
            //this.roleManager = roleManager;
            _context = context;
        }
       
      
        //public ProductosController(UserManager<IdentityUser> userManager,
        //    RoleManager<IdentityRole>roleManager)
        //{
        //    this.userManager = userManager;
        //    this.roleManager = roleManager;
        // }
        public async Task<IActionResult> Index()
        { 
            //if (User.Identity.IsAuthenticated)
            //{
            //    await roleManager.CreateAsync(new IdentityRole("Admin"));
            //    var user = await userManager.GetUserAsync(HttpContext.User);
            //    await userManager.AddToRoleAsync(user, "Admin");
            //}
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
        [Authorize(Roles ="Admin")]
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
        public IActionResult DeleteProducto(int? ide)
        {
            var pro = _context.Producto.Find(ide);
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
