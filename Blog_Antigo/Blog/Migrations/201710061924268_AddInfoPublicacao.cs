namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInfoPublicacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DataPublicacao", c => c.DateTime());
            AddColumn("dbo.Posts", "Publicado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Publicado");
            DropColumn("dbo.Posts", "DataPublicacao");
        }
    }
}
