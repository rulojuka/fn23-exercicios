using Blog.DAO;
using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            PostDAO postDAO = new PostDAO();
            var listaDePosts = postDAO.Lista();
            return View(listaDePosts);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Adiciona(post);
            return RedirectToAction("Index");
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();
            IList<Post> lista = dao.FiltraPorCategoria(categoria);
            return View("Index", lista);
        }

        public ActionResult RemovePost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult EditaPost(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Atualiza(post);
            return RedirectToAction("Index");
        }
    }
}