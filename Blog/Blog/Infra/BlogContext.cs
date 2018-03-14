using Blog.Models;
using System.Data.Entity;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=blog")
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}