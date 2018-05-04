using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Models
{
    public class PermissaoManager : RoleManager<IdentityRole>
    {
        public PermissaoManager(IRoleStore<IdentityRole,string> store) : base(store)
        {
        }
    }
}