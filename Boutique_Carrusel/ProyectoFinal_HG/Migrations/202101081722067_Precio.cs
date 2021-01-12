namespace ProyectoFinal_HG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Precio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ropas", "Precio", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ropas", "Precio", c => c.String());
        }
    }
}
