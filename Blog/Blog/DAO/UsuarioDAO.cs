using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public Usuario BuscaPorNome(string nome)
        {
            Usuario usuario = contexto.Users.FirstOrDefault(u => u.UserName.Equals(nome));
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new ArgumentException("Usuario nao encontrado");
            }
        }

        public void CriaPapel(string nomeDoPapel)
        {
            PermissaoManager permissaoManager =  HttpContext.Current.GetOwinContext().Get<PermissaoManager>();
            if (!permissaoManager.RoleExists(nomeDoPapel))
            {
                var papel = new IdentityRole();
                papel.Name = nomeDoPapel;
                permissaoManager.Create(papel);
            }
            else
            {
                throw new ArgumentException("Já existe um Role com esse nome");
            }
        }

        public void AdicionaPapelAoUsuario(string papel, string username)
        {
            UsuarioManager manager = HttpContext.Current.GetOwinContext().GetUserManager<UsuarioManager>();
            Usuario usuarioDoBanco = BuscaPorNome(username);
            manager.AddToRole(usuarioDoBanco.Id, papel);
        }
    }
}