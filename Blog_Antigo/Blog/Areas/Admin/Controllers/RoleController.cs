using Blog.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public RoleController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        [HttpGet]
        public ActionResult Cria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cria(string nomeDoPapel)
        {
            usuarioDAO.CriaPapel(nomeDoPapel);
            return RedirectToAction("Index", "Post", new { area = "Admin" });
        }

        [HttpGet]
        public ActionResult AdicionaAoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaAoUsuario(String papel, string usuario)
        {
            usuarioDAO.AdicionaPapelAoUsuario(papel, usuario);
            return RedirectToAction("Index", "Post", new { area = "Admin" });
        }
    }
}