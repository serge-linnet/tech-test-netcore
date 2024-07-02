using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.EntityModelMappers.TodoItems;
using Todo.Services;
using Todo.Views.TodoItem;

namespace Todo.ViewComponents.TodoItem
{
    [ViewComponent(Name = "CreateTodoItemModal")]
    public class CreateTodoItemModalViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateTodoItemModalViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int todoListId)
        {
            var todoList = await _dbContext.SingleTodoListAsync(todoListId);
            var responsibleParties = await _dbContext.UserSelectListItemsAsync();
            var userId = (User as ClaimsPrincipal).Id();
            var fields = TodoItemCreateFieldsFactory.Create(todoList, responsibleParties, userId);
            return View(fields);
        }
    }
}
