namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "dbo.Entradas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movimiento = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Facturacion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facturacions", t => t.Facturacion_Id)
                .Index(t => t.Facturacion_Id);
            
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
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProveedor = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.IdProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.IdProveedor, cascadeDelete: true)
                .Index(t => t.IdProveedor)
                .Index(t => t.IdProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "IdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Stocks", "IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "Facturacion_Id", "dbo.Facturacions");
            DropForeignKey("dbo.Facturacions", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Stocks", new[] { "IdProducto" });
            DropIndex("dbo.Stocks", new[] { "IdProveedor" });
            DropIndex("dbo.Productoes", new[] { "Facturacion_Id" });
            DropIndex("dbo.Facturacions", new[] { "IdCliente" });
            DropTable("dbo.Stocks");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Productoes");
            DropTable("dbo.Facturacions");
            DropTable("dbo.Entradas");
            DropTable("dbo.Clientes");
        }
    }
}
