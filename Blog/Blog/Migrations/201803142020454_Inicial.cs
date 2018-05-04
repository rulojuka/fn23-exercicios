namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Posts",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Titulo = c.String(),
            //            Resumo = c.String(),
            //            Categoria = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
