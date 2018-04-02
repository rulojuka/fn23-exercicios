namespace Blog.Migrations
{
    using Blog.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Infra.BlogContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            Usuario usuarioAdmin = new Usuario()
            {
                UserName = "admin",
                PasswordHash = password,
                UltimoLogin = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            context.Users.AddOrUpdate(u => u.UserName, usuarioAdmin);
        }
    }
}
