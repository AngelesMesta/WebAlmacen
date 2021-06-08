using Almacen.Data;
using Almacen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Almacen.Controllers
{
    [Authorize]
    public class ESController : Controller
    {
        private readonly AlmacenContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ESController(AlmacenContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<ES> ListaES = _context.ES;
            return View(ListaES);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ES es)
        {
            var pro = _context.Producto.Find(es.IdPro);
            if (ModelState.IsValid)
            {
                if(es.Tipo==1)
                {
                    pro.Existencia = pro.Existencia + es.cantidad;
                }
                else if(es.Tipo==2)
                {
                    pro.Existencia = pro.Existencia - es.cantidad;
                }
                _context.Producto.Update(pro);
                _context.ES.Add(es);
                _context.SaveChanges();
                TempData["mensaje"] = "El movimiento se ha añadido de manera correcta";
                return RedirectToAction("Index");
            }
            return View();
        }
        //private IHostingEnvironment Environment;
       

      
        [HttpPost]
        public ActionResult SubirArchivo(List<IFormFile> postedFiles)
        {
            string wwwpath = this._hostingEnvironment.WebRootPath;
            string contentPath = this._hostingEnvironment.ContentRootPath;
            string path = Path.Combine(this._hostingEnvironment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            List<string> uploadedFiles = new List<string>();

            foreach (IFormFile postedFile in postedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(filename);
                    ViewBag.Message += string.Format("Subido");
                }
            }
            return Content(path);
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

            TempData["mensaje"] = "El movimiento se ha eliminado de manera correcta";
            return RedirectToAction("Index");

        }
        //[HttpPost]
        //public ActionResult SubirArchivo(HttpPostedFileBase file)
        //{


        //    String NombreImagen = "Archivo" + file.FileName;

        //    file.SaveAs(Server.MapPath("~/ImagenesSubidas/") + NombreImagen);

        //    return View();
        //}
    }
}

