﻿using Blog.Infra;
using Blog.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista()
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return lista;
            }
        }

        public void Adiciona(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }
    }
}