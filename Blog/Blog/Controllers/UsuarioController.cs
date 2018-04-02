using Blog.DAO;
using Blog.Filters;
using Blog.Models;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AutorizacaoFilter]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = this.usuarioDAO.Busca(model.LoginName, model.Password);
                if (usuario != null)
                {
                    Session["usuario"] = usuario;
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }
            return View("Login", model);
        }
    }
}