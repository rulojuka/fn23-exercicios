namespace Blog.Migrations
{
    using Blog.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Infra.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Usuario usuarioAdmin = new Usuario
            {
                Id = 1,
                Nome = "admin",
                Email = "admin@caelum.com.br",
                Senha = "123456"
            };
            context.Usuarios.AddOrUpdate(usuarioAdmin);
        }
    }
}
