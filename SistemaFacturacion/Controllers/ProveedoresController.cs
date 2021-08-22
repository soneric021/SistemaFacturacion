using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaNegocios;

namespace SistemaFacturacion.Controllers
{
    public class ProveedoresController : Controller
    {
        private ServicioProveedor servicioProveedor = new ServicioProveedor();

        // GET: Proveedores
        public ActionResult Index(string searchString)
        {
            var proveedor = servicioProveedor.Get();
            if (!String.IsNullOrEmpty(searchString))
            {
            
                proveedor = proveedor.Where(x => x.Nombre.ToLower()== searchString.ToLower()
                || x.Email.ToLower() == searchString.ToLower()).ToList();
            }
            return View(proveedor);
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = servicioProveedor.GetById(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Telefono,Email")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                servicioProveedor.Create(proveedor);
                return RedirectToAction("Index");
            }

            return View(proveedor);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = servicioProveedor.GetById(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Telefono,Email")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                servicioProveedor.Update(proveedor);
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = servicioProveedor.GetById(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicioProveedor.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
