using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> lista;

        public PostController()
        {
            this.lista = new List<Post>
            {
                new Post { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
                new Post { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" },
                new Post { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" },
                new Post { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }
            };
        }

        // GET: Post
        public ActionResult Index()
        {
            var listaDePosts = new List<Post>()
            {
                new Post() { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
                new Post() { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" },
                new Post() { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" },
                new Post() { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }
            };
            return View(listaDePosts);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            lista.Add(post);
            return View("Index", lista);
        }
    }
}