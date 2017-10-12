namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaNullableUltimoLogin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UltimoLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UltimoLogin", c => c.DateTime(nullable: false));
        }
    }
}
