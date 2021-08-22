using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocios;
using CapaEntidades;

namespace SistemaFacturacion.Controllers
{
    public class StockController : Controller
    {
        private ServicioStock servicioStock = new ServicioStock();
        private ServicioProveedor servicioProveedor = new ServicioProveedor();
        private ServicioProducto servicioProducto = new ServicioProducto();
        // GET: Stock
        public ActionResult Index()
        {
            return View(servicioStock.Get());
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            ViewData["productos"] = servicioProducto.Get();
            ViewData["proveedores"] = servicioProveedor.Get();
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdProveedor,IdProductoStock,Cantidad")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                servicioStock.Create(stock);
                return RedirectToAction("Index");
            }

            return View(stock);
        }

    }
}