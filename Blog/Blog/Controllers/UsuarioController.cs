using Blog.DAO;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
                Usuario usuario = manager.Find(model.LoginName, model.Password);
                if (usuario != null)
                {
                    ClaimsIdentity identity = manager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { }, identity);
                    usuarioDAO.AtualizaLogin(usuario);
                }
                return RedirectToAction("Index", "Post", new { area = "Admin" });
            }
            else
            {
                return View(model);
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario()
                {
                    UserName = model.LoginName,
                    Email = model.Email
                };
                UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
                IdentityResult resultado = manager.Create(usuario, model.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(string erro in resultado.Errors)
                    {
                        ModelState.AddModelError("blabla", erro);
                    }
                }
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Index()
        {
            return View(usuarioDAO.Lista());
        }
    }
}