using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class SistemaFacturacionDbContext : DbContext
    {
        public SistemaFacturacionDbContext() : base("DefaultConnection")
        {


        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Entrada> entradas { get; set; }
        public DbSet<Facturacion> facturaciones { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }

    }
}


