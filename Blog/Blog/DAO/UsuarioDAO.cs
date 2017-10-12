using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}