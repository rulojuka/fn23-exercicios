using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAO
{
    public class PostDAO
    {
        private BlogContext contexto;

        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }
        public void Adiciona(Post post)
        {
            contexto.Posts.Add(post);
            contexto.SaveChanges();
        }

        public IList<Post> Lista()
        {
            IList<Post> lista;
            lista = contexto.Posts.ToList();
            contexto.SaveChanges();
            return lista;
        }

        public IList<Post> BuscaCategoria(string categoria)
        {
            IList<Post> lista;
            //Usando os métodos do LINQ
            lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();

            // Usando sql no LINQ
            //var query = from p in contexto.Posts where p.Categoria.Contains(categoria) select p;
            //lista = query.ToList();
            return lista;
        }

        public void Edita(Post post)
        {
            contexto.Entry(post).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Publica(int id)
        {
            var post = contexto.Posts.Find(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            contexto.SaveChanges();
        }

        public Post BuscaPost(int id)
        {
            Post post;
            post = contexto.Posts.Find(id);
            return post;
        }

        public IList<string> Autocomplete(string term)
        {
            var model = contexto.Posts
                .Where(p => p.Categoria.Contains(term))
                .Select(p => p.Categoria)
                .Distinct()
                .ToList();
            return model;
        }

        public void Remove(int id)
        {
            Post post = contexto.Posts.Find(id);
            contexto.Posts.Remove(post);
            contexto.SaveChanges();
        }

        public IList<Post> Busca(string termo)
        {
            return contexto.Posts
                .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Categoria.Contains(termo)))
                .Select(p => p)
                .ToList();
        }
    }
}