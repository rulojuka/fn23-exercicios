namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Autor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Autor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "Autor_Id");
            AddForeignKey("dbo.Posts", "Autor_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Autor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Autor_Id" });
            DropColumn("dbo.Posts", "Autor_Id");
        }
    }
}
