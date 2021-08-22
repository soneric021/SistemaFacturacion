using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class ServicioFacturacion 
    {
        private FacturacionDatos facturacionDatos = new FacturacionDatos();
        private StockDatos StockDatos = new StockDatos();
        private ClienteDatos clienteDatos = new ClienteDatos();
        public void AgregarFacturacion(FacturacionViewModel facturacion)
        {
            var cliente = clienteDatos.GetById(facturacion.IdCliente);
            var descuento = 0.0;
            var itbis = facturacion.Total * 0.18;
            if (cliente.Categoria == Categoria.Premium)
            {
                descuento = facturacion.Total * 0.05;
                facturacion.Total -= descuento;
                
            }
            var factura = new Facturacion()
            {
                Fecha = facturacion.Fecha,
                IdCliente = facturacion.IdCliente,
                Total = facturacion.Total + itbis,
                Descuento = descuento,
                Itbis = itbis
            };
            
            
            List<DetalleFactura> detalle = new List<DetalleFactura>();
            
           
            foreach (ProductoViewModel producto in facturacion.productos)
            {
                detalle.Add(new DetalleFactura() {  IdProducto = producto.Id, Cantidad=producto.Cantidad });
                StockDatos.UpdateStockByIdProduct(producto.Id, producto.Cantidad);
            }
            factura.detalleFacturas = detalle;
            facturacionDatos.Create(factura);
        }
        public List<Facturacion> Get()
        {
            return facturacionDatos.Get();
        }
        public IEnumerable<DetalleFactura> Get(int? id)
        {
            return facturacionDatos.GetDetalleFacturasByFactura(id);
        }
    }
}
