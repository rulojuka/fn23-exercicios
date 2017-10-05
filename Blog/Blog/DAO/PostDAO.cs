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

        public IList<Post> BuscaCategoria(string categoria)
        {
            IList<Post> lista;
            using (BlogContext contexto = new BlogContext())
            {
                //Usando os métodos do LINQ
                lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                
                // Usando sql no LINQ
                //var query = from p in contexto.Posts where p.Categoria.Contains(categoria) select p;
                //lista = query.ToList();
            }
            return lista;
        }
    }
}