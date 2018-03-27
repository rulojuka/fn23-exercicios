using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext contexto;
        private PostDAO dao;

        public HomeController()
        {
            contexto = new BlogContext();
            dao = new PostDAO(contexto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contexto.Dispose();
            }
            base.Dispose(disposing);
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