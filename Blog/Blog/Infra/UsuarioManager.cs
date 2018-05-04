using Blog.Models;
using Microsoft.AspNet.Identity;

namespace Blog.Infra
{
    public class UsuarioManager : UserManager<Usuario>
    {
        public UsuarioManager(IUserStore<Usuario> store) : base(store)
        {
        }
    }
}