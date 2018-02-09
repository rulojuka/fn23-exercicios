using Blog.DAO;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        PostDAO postDAO;
        UsuarioDAO usuarioDAO;

        public PostController(PostDAO postDAO, UsuarioDAO usuarioDAO)
        {
            this.postDAO = postDAO;
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            return View(postDAO.Lista());
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Post post)
        {
            if (ModelState.IsValid)
            {
                postDAO.Adiciona(post, usuarioDAO.UsuarioLogado());
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(postDAO.BuscaPost(id));
        }

        [HttpPost]
        public ActionResult Edit(Post post)
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

        public ActionResult Remove(int id)
        {
            postDAO.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Publicar(int id)
        {
            postDAO.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            return Json(postDAO.Autocomplete(term));
        }
    }
}