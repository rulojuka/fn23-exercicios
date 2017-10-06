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
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            postDAO.Adiciona(post);
            return RedirectToAction("Index");
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            return View("Index",postDAO.BuscaCategoria(categoria));
        }

        public ActionResult RemovePost(int id)
        {
            postDAO.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            return View(postDAO.Busca(id));
        }

        public ActionResult EditaPost(Post post)
        {
            postDAO.Edita(post);
            return RedirectToAction("Index");
        }

        public ActionResult PublicaPost(int id)
        {
            postDAO.Publica(id);
            return RedirectToAction("Index");
        }
    }
}