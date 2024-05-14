﻿namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregandoCampoPrecioADetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleVentas", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetalleVentas", "Precio");
        }
    }
}
