namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDescuentoItbis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturacions", "Itbis", c => c.Double(nullable: false));
            AddColumn("dbo.Facturacions", "Descuento", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturacions", "Descuento");
            DropColumn("dbo.Facturacions", "Itbis");
        }
    }
}
