using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public class TodoItemCreateFieldsFactory
    {
        public static TodoItemCreateFields Create(TodoList todoList, IEnumerable<SelectListItem> responsibleParties, string defaultResponsibleUserId)
        {
            return new TodoItemCreateFields(todoList.TodoListId, todoList.Title, defaultResponsibleUserId, responsibleParties);
        }
    }
}