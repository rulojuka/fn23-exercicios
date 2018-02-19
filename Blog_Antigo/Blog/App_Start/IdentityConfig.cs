using Blog.Infra;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            BlogContext contexto = new BlogContext();

            /*Cria uma instância de UsuarioManager que será injetada nas requisições HTTP pelo OWIN*/
            app.CreatePerOwinContext<UsuarioManager>(() => {
                IUserStore<Usuario> userStore = new UserStore<Usuario>(contexto);
                return new UsuarioManager(userStore);
            });

            app.CreatePerOwinContext<PermissaoManager>(() =>
            {
                IRoleStore<IdentityRole,string> roleStore = new RoleStore<IdentityRole>(contexto);
                return new PermissaoManager(roleStore);
            });

            /*Usa cookies como forma de autenticação*/
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                /*Aponta para cá se o usuário não estiver logado*/
                LoginPath = new PathString("/Usuario/Login")
            });


        }
    }
}