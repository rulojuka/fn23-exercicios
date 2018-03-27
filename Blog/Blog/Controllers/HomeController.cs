using Blog.DAO;
using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public ActionResult Busca(string termo)
        {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            ViewBag.Termo = termo;
            return View("Index", posts);
        }
    }
}