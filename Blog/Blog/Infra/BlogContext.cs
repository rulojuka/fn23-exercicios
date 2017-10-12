using Blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Infra
{
    public class BlogContext : IdentityDbContext<Usuario>
    {
        public DbSet<Post> Posts { get; set; }
        public BlogContext() : base("name=blog")
        {
        }
    }
}