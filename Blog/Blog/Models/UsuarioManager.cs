using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UsuarioManager : UserManager<Usuario>
    {
        public UsuarioManager(IUserStore<Usuario> store) : base(store)
        {
        }
    }
}