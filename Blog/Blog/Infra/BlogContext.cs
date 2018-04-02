using Blog.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=blog")
        {
            // Loga as SQLs
            Database.Log = s => Debug.Write(s);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}