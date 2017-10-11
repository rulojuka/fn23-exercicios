using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        PostDAO postDAO;

        public HomeController()
        {
            postDAO = new PostDAO();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(postDAO.Lista());
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
                postDAO.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NovoPost",post);
            }
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            return View("Index", postDAO.BuscaCategoria(categoria));
        }

        public ActionResult RemovePost(int id)
        {
            postDAO.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            return View(postDAO.BuscaPost(id));
        }

        public ActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                postDAO.Edita(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Visualiza", post);
            }
        }

        public ActionResult PublicaPost(int id)
        {
            postDAO.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            return Json(postDAO.Autocomplete(term));
        }

        public ActionResult Busca(string termo)
        {
            IList<Post> lista = postDAO.Busca(termo);
            ViewBag.FezBusca = true;
            ViewBag.Vazio = (lista.Count == 0);
            ViewBag.Termo = termo;
            return View("Index", lista);
        }
    }
}