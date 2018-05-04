using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO dao;

        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }

        // GET: Home
        public ActionResult Index()
        {
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public ActionResult Busca(string termo)
        {
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            ViewBag.Termo = termo;
            return View("Index", posts);
        }
    }
}