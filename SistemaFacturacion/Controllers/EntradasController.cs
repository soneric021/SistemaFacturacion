using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocios;

namespace SistemaFacturacion.Controllers
{
    public class EntradasController : Controller
    {
        private ServicioEntrada servicioEntrada = new ServicioEntrada();
        private ServicioProducto servicioProducto = new ServicioProducto();
        private ServicioProveedor servicioProveedor = new ServicioProveedor();
        // GET: Entradas
        public ActionResult Index(string filtroFecha, string filtroProducto, string filtroProveedor)
        {
            var entradas = servicioEntrada.Get();
            ViewBag.conteo = 0;
            ViewBag.sumatoria = 0;
            ViewBag.promedio = 0;
            //ViewBag.promedio 
            if (!String.IsNullOrEmpty(filtroFecha))
            {
                entradas = entradas.Where(x => x.Fecha.Date == DateTime.Parse(filtroFecha).Date).ToList();
            }
            if (!String.IsNullOrEmpty(filtroProducto))
            {
                entradas = entradas.Where(x => x.IdProducto == int.Parse(filtroProducto)).ToList();
            }
            if (!String.IsNullOrEmpty(filtroProveedor))
            {
                entradas = entradas.Where(x => x.IdProveedor == int.Parse(filtroProveedor)).ToList();
            }
            if(!String.IsNullOrEmpty(filtroFecha) || !String.IsNullOrEmpty(filtroProducto) || !String.IsNullOrEmpty(filtroProveedor) && entradas.Count > 0)
            {
                ViewBag.conteo = entradas.Count;
                ViewBag.sumatoria = entradas.Sum(x => x.producto.Precio);
                if(entradas.Count > 1)
                {
                    ViewBag.promedio = entradas.Sum(x => x.producto.Precio) / entradas.Count;
                }
            }
            ViewBag.productos = servicioProducto.Get();
            ViewBag.proveedores = servicioProveedor.Get();
            return View(entradas);
        }
    }
}