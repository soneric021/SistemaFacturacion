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
            if (cliente.Categoria == Categoria.Premium)
            {
                facturacion.Total -= facturacion.Total * 0.05;
            }
            var factura = new Facturacion()
            {
                Fecha = facturacion.Fecha,
                IdCliente = facturacion.IdCliente,
                Total = facturacion.Total
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
        public IEnumerable<Facturacion> Get()
        {
            return facturacionDatos.Get();
        }
        public IEnumerable<DetalleFactura> Get(int? id)
        {
            return facturacionDatos.GetDetalleFacturasByFactura(id);
        }
    }
}
