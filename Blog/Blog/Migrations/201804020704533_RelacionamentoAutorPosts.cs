namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionamentoAutorPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Autor_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Autor_Id");
            AddForeignKey("dbo.Posts", "Autor_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Autor_Id", "dbo.Usuarios");
            DropIndex("dbo.Posts", new[] { "Autor_Id" });
            DropColumn("dbo.Posts", "Autor_Id");
        }
    }
}
