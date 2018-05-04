using Blog.Infra;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.DAO
{
    public class UsuarioDAO
    {
        private BlogContext contexto;

        public UsuarioDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }

        public Usuario Busca(string login, string senha)
        {
            UsuarioManager manager = HttpContext.Current.GetOwinContext().GetUserManager<UsuarioManager>();
            Usuario retorno = manager.Find(login, senha);
            return retorno;
        }

        public void Adiciona(Usuario usuario)
        {
            contexto.Users.Add(usuario);
            contexto.SaveChanges();
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