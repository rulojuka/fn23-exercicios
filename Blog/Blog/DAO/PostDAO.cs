using Blog.Infra;
using Blog.Models;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                //var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                var lista = (from p in contexto.Posts where p.Categoria.Contains(categoria) select p).ToList();
                return lista;
            }
        }

        public void Remove(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();

                // Para fazer em apenas uma query
                //Post post = new Post { Id = id };
                //contexto.Entry(post).State = EntityState.Deleted;
                //contexto.SaveChanges();
            }
        }

        public Post BuscaPorId(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                return post;
            }
        }

        public void Atualiza(Post post)
        {
            using (var contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}