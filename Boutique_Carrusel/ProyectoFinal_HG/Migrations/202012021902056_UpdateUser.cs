namespace ProyectoFinal_HG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ropas", name: "Modista_Id", newName: "ApplicationUser");
            RenameIndex(table: "dbo.Ropas", name: "IX_Modista_Id", newName: "IX_ApplicationUser");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Ropas", name: "IX_ApplicationUser", newName: "IX_Modista_Id");
            RenameColumn(table: "dbo.Ropas", name: "ApplicationUser", newName: "Modista_Id");
        }
    }
}
