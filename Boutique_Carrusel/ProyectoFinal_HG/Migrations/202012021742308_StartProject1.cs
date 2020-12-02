namespace ProyectoFinal_HG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartProject1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ropas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.String(),
                        CategoriaId = c.Int(nullable: false),
                        Modista_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Modista_Id)
                .Index(t => t.CategoriaId)
                .Index(t => t.Modista_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ropas", "Modista_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ropas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Ropas", new[] { "Modista_Id" });
            DropIndex("dbo.Ropas", new[] { "CategoriaId" });
            DropTable("dbo.Ropas");
            DropTable("dbo.Categorias");
        }
    }
}
