namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 13),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdFacturacion = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturacions", t => t.IdFacturacion, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdFacturacion)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Facturacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        IdProductoStock = c.Int(nullable: false),
                        IdProveedor = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductoStock)
                .ForeignKey("dbo.Proveedors", t => t.IdProveedor, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.IdProductoStock)
                .Index(t => t.IdProductoStock)
                .Index(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 13),
                        Nombre = c.String(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entradas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movimiento = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        IdProveedor = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.IdProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.IdProveedor, cascadeDelete: true)
                .Index(t => t.IdProveedor)
                .Index(t => t.IdProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entradas", "IdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Entradas", "IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.Stocks", "IdProductoStock", "dbo.Productoes");
            DropForeignKey("dbo.Stocks", "IdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.DetalleFacturas", "IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.DetalleFacturas", "IdFacturacion", "dbo.Facturacions");
            DropForeignKey("dbo.Facturacions", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Entradas", new[] { "IdProducto" });
            DropIndex("dbo.Entradas", new[] { "IdProveedor" });
            DropIndex("dbo.Stocks", new[] { "IdProveedor" });
            DropIndex("dbo.Stocks", new[] { "IdProductoStock" });
            DropIndex("dbo.Facturacions", new[] { "IdCliente" });
            DropIndex("dbo.DetalleFacturas", new[] { "IdProducto" });
            DropIndex("dbo.DetalleFacturas", new[] { "IdFacturacion" });
            DropTable("dbo.Entradas");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Stocks");
            DropTable("dbo.Productoes");
            DropTable("dbo.Facturacions");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.Clientes");
        }
    }
}
