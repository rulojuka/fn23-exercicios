using Blog.DAO;
using Blog.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }

        // GET: Post
        public ActionResult Index()
        {
            var listaDePosts = dao.Lista();
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
                Usuario logado = (Usuario) Session["usuario"];
                dao.Adiciona(post, logado);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoPost", post);
            }
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            IList<Post> lista = dao.FiltraPorCategoria(categoria);
            return View("Index", lista);
        }

        public ActionResult RemovePost(int id)
        {
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
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
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }
    }
}