using Blog.DAO;
using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
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
            return View(new Post());
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoPost", post);
            }
            
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
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
            
        }

        public ActionResult PublicaPost(int id)
        {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            PostDAO dao = new PostDAO();
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }
    }
}