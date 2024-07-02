using Todo.Models.Identity;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public class UserSummaryViewmodelFactory
    {
        public static UserSummaryViewmodel Create(ApplicationUser identityUser)
        {
            return new UserSummaryViewmodel(identityUser.UserName, identityUser.Email, identityUser.DisplayName);
        }
    }
}