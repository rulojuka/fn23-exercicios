using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAO
{
    public class PostDAO
    {
        public void Adiciona(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }

        public IList<Post> Lista()
        {
            IList<Post> lista;
            using (BlogContext contexto = new BlogContext())
            {
                lista = contexto.Posts.ToList();
                contexto.SaveChanges();
            }
            return lista;
        }
    }
}