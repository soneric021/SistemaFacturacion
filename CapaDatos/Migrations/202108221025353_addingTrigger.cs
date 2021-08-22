namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTrigger : DbMigration
    {
        public override void Up()
        {
            string trigger = @"Create trigger AGREGARENTRADA 
                             on Stocks
                             For insert
                             as
                            DECLARE @Movimiento Varchar(100)
                            DECLARE @IdProveedor VARCHAR(50)
                            DECLARE @IdProducto INT
                            DECLARE @Fecha DATETIME
                            DECLARE @Cantidad INT
                            SET @IdProveedor = (SELECT IdProveedor FROM Inserted)
                            SET @IdProducto = (SELECT IdProductoStock FROM Inserted)
                            SET @Movimiento = 'Se agregaron ' + CONVERT(varchar, (SELECT Cantidad FROM Inserted)) + ' ' + (Select p.Nombre from inserted s inner join Productoes p on s.idProductoStock = p.Id) + ' por el proveedor ' + (Select p.Nombre from inserted s inner join Proveedors p on s.IdProveedor = p.Id)
                            SET @Fecha = (SELECT GETDATE())
                            SET @Cantidad = (SELECT Cantidad FROM Inserted)
                            insert Entradas(Movimiento, Fecha, IdProducto, IdProveedor, Cantidad) values(@Movimiento, @Fecha, @IdProducto,@IdProveedor,@Cantidad)
                            go";
            Sql(trigger);
        
        }

        public override void Down()
        {
            Sql("DROP TRIGGER AGREGARENTRADA");
        }
    }
}
