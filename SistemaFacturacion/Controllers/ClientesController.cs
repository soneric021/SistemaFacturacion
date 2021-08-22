using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaNegocios;

namespace SistemaFacturacion.Controllers
{
    public class ClientesController : Controller
    {
        private ServicioCliente servicioCliente = new ServicioCliente();

        // GET: Clientes
        public ActionResult Index(string searchString, string filtroCategoria)
        {
            ViewBag.categorias = Enum.GetValues(typeof(CapaEntidades.Categoria));
            ViewBag.clienteCantidad = 0;
            var clientes = servicioCliente.Get();

            if (!String.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(x => x.Nombre.ToLower() == searchString.ToLower()).ToList();
            }
            if(!String.IsNullOrEmpty(filtroCategoria))
            {
                if(filtroCategoria.ToLower() == "Premium".ToLower())
                {
                    clientes = clientes.Where(x => x.Categoria == Categoria.Premium).ToList();
                }
                else
                {
                    clientes = clientes.Where(x => x.Categoria == Categoria.Regular).ToList();
                }
                ViewBag.clienteCantidad = clientes.Count;
            }
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = servicioCliente.GetById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Telefono,Email,Categoria")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                servicioCliente.Create(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = servicioCliente.GetById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Telefono,Email,Categoria")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                servicioCliente.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = servicioCliente.GetById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicioCliente.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
