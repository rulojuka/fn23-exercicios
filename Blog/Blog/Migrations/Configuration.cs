namespace Blog.Migrations
{
    using Blog.DAO;
    using Blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blog.Infra.BlogContext context)
        {
            /* Cria papel "admin" */
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "admin" };

                roleManager.Create(role);
            }

            /* Cria usuário "admin" e adiciona o role "admin" nele */
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("admin");
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<Usuario>(context);
                var manager = new UserManager<Usuario>(store);
                Usuario usuarioAdmin = new Usuario()
                {
                    UserName = "admin",
                    PasswordHash = password,
                    UltimoLogin = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                manager.Create(usuarioAdmin);
                manager.AddToRole(usuarioAdmin.Id, "admin");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
