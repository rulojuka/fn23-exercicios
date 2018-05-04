namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacaoPost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Titulo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Posts", "Resumo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Resumo", c => c.String());
            AlterColumn("dbo.Posts", "Titulo", c => c.String());
        }
    }
}
