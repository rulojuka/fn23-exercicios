using Blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;

namespace Blog.Infra
{
    public class BlogContext : IdentityDbContext<Usuario>
    {
        public BlogContext() : base("name=blog")
        {
            // Loga as SQLs
            Database.Log = s => Debug.Write(s);
        }

        public DbSet<Post> Posts { get; set; }
    }
}