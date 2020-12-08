namespace ProyectoFinal_HG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Descripcion", c => c.String());
            AddColumn("dbo.AspNetUsers", "Hobbies", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ropa", c => c.String());
            AddColumn("dbo.AspNetUsers", "Videos", c => c.String());
            AddColumn("dbo.AspNetUsers", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Photo");
            DropColumn("dbo.AspNetUsers", "Videos");
            DropColumn("dbo.AspNetUsers", "Ropa");
            DropColumn("dbo.AspNetUsers", "Hobbies");
            DropColumn("dbo.AspNetUsers", "Descripcion");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
