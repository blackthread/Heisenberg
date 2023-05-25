using Microsoft.AspNetCore.Identity;


namespace Heisenberg.Persistence.IdentityModels
{
    public  class AppUser : IdentityUser
    {
        public string? Name { get;  set; }
    }
}
