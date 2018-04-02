using Blog.Infra;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
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
    }
}