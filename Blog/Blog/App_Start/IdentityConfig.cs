using Blog.Infra;
using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Blog.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<UsuarioManager>(() => {
                BlogContext contexto = new BlogContext();
                UserStore<Usuario> userStore = new UserStore<Usuario>(contexto);
                return new UsuarioManager(userStore);
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Usuario/Login"),
            });
        }
    }
}