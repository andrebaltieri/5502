namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 60),
                        ISBN = c.String(nullable: false, maxLength: 32),
                        DataLancamento = c.DateTime(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LivroAutor",
                c => new
                    {
                        Autor_Id = c.Int(nullable: false),
                        Livro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Autor_Id, t.Livro_Id })
                .ForeignKey("dbo.Autor", t => t.Autor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Livro", t => t.Livro_Id, cascadeDelete: true)
                .Index(t => t.Autor_Id)
                .Index(t => t.Livro_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LivroAutor", "Livro_Id", "dbo.Livro");
            DropForeignKey("dbo.LivroAutor", "Autor_Id", "dbo.Autor");
            DropForeignKey("dbo.Livro", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.LivroAutor", new[] { "Livro_Id" });
            DropIndex("dbo.LivroAutor", new[] { "Autor_Id" });
            DropIndex("dbo.Livro", new[] { "CategoriaId" });
            DropTable("dbo.LivroAutor");
            DropTable("dbo.Categoria");
            DropTable("dbo.Livro");
            DropTable("dbo.Autor");
        }
    }
}
