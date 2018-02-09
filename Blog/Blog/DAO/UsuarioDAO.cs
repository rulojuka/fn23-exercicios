using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web.Mvc;

namespace Blog.DAO
{
    public class UsuarioDAO
    {
        private BlogContext contexto;

        public UsuarioDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }
        

        public IList<Usuario> Lista()
        {
            return contexto.Users.ToList();
        }

        public void AtualizaLogin(Usuario usuario)
        {
            Usuario usuarioDoBanco = contexto.Users.Find(usuario.Id);
            usuarioDoBanco.UltimoLogin = DateTime.Now;
            contexto.SaveChanges();
        }

        public Usuario UsuarioLogado()
        {
            UsuarioManager manager = HttpContext.Current.GetOwinContext().GetUserManager<UsuarioManager>();
            return contexto.Users.Find(HttpContext.Current.User.Identity.GetUserId());
        }
    }
}