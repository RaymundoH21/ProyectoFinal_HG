namespace ProyectoFinal_HG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Current : DbMigration
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
                        DisenadorId = c.Int(nullable: false),
                        Existencias = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Precio = c.String(),
                        Picture = c.String(),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disenadors", t => t.DisenadorId, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .Index(t => t.DisenadorId)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.Disenadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoriaId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Descripcion", c => c.String());
            AddColumn("dbo.AspNetUsers", "Hobbies", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ropa", c => c.String());
            AddColumn("dbo.AspNetUsers", "Videos", c => c.String());
            AddColumn("dbo.AspNetUsers", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ropas", "Categoria_Id", "dbo.Categorias");
            DropForeignKey("dbo.Ropas", "DisenadorId", "dbo.Disenadors");
            DropForeignKey("dbo.Disenadors", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Disenadors", new[] { "CategoriaId" });
            DropIndex("dbo.Ropas", new[] { "Categoria_Id" });
            DropIndex("dbo.Ropas", new[] { "DisenadorId" });
            DropColumn("dbo.AspNetUsers", "Photo");
            DropColumn("dbo.AspNetUsers", "Videos");
            DropColumn("dbo.AspNetUsers", "Ropa");
            DropColumn("dbo.AspNetUsers", "Hobbies");
            DropColumn("dbo.AspNetUsers", "Descripcion");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Disenadors");
            DropTable("dbo.Ropas");
            DropTable("dbo.Categorias");
        }
    }
}
