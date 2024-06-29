using Microsoft.AspNetCore.Identity;

namespace Todo.Models.Identity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(string userName): base(userName)
        {
            
        }

        public string DisplayName { get; set; }
    }
}
