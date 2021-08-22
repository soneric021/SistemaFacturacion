using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaFacturacion.Controllers
{
    public class FacturacionController : Controller
    {
        private ServicioFacturacion servicioFacturacion = new ServicioFacturacion();
        private ServicioProducto servicioProducto = new ServicioProducto();
        private ServicioCliente servicioCliente = new ServicioCliente();
        // GET: Facturacion
        public ActionResult Index(string filtroCliente, string filtroFecha)
        {
            var facturacion = servicioFacturacion.Get();
            ViewBag.clientes = servicioCliente.Get();
            ViewBag.conteo = 0;
            ViewBag.sumatoria = 0;
            ViewBag.max = 0;
            ViewBag.min = 0;
            ViewBag.promedio = 0;
            if (!String.IsNullOrEmpty(filtroFecha))
            {
                facturacion = facturacion.Where(x => x.Fecha.Date == DateTime.Parse(filtroFecha)).ToList();
            }
            if (!String.IsNullOrEmpty(filtroCliente))
            {
                facturacion = facturacion.Where(x => x.IdCliente == int.Parse(filtroCliente)).ToList();
            }
            if (!String.IsNullOrEmpty(filtroFecha) || !String.IsNullOrEmpty(filtroCliente) && facturacion.Count > 0) {
                ViewBag.conteo = facturacion.Count;
                ViewBag.sumatoria = facturacion.Sum(x => x.Total);
                ViewBag.max = facturacion.Max(x => x.Total);
                ViewBag.min = facturacion.Min(x => x.Total);
                if(facturacion.Count > 1)
                {
                    ViewBag.promedio = facturacion.Sum(x => x.Total) / facturacion.Count;
                }
            }

            return View(facturacion);
        }
        public ActionResult Details(int? id)
        {
            return View(servicioFacturacion.Get(id));
        }
        // GET: Stock/Create
        public ActionResult Create()
        {
            ViewBag.productos = servicioProducto.Get().Where(x => x.stock != null && x.stock.Cantidad > 0);
            ViewBag.clientes = servicioCliente.Get();
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(FacturacionViewModel facturacion)
        {
            if (facturacion.Fecha == null || facturacion.productos == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                servicioFacturacion.AgregarFacturacion(facturacion);
                return  new HttpStatusCodeResult(HttpStatusCode.OK); ;
        }
    }
}