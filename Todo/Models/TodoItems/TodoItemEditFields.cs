using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemEditFields
    {
        public int TodoListId { get; set; }

        public string Title { get; set; }

        public string TodoListTitle { get; set; }

        public int TodoItemId { get; set; }

        [Display(Name = "Is Done")]
        public bool IsDone { get; set; }

        [Display(Name = "Responsible Party")]
        public string ResponsiblePartyId { get; set; }

        public Importance Importance { get; set; }

        public IEnumerable<SelectListItem> ResponsibleParties { get; } = new List<SelectListItem>();

        public TodoItemEditFields() { }

        public TodoItemEditFields(int todoListId, string todoListTitle, int todoItemId, string title, bool isDone, string responsiblePartyId, Importance importance, IEnumerable<SelectListItem> responsibleParties)
        {
            TodoListId = todoListId;
            TodoListTitle = todoListTitle;
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;
            ResponsiblePartyId = responsiblePartyId;
            Importance = importance;
            ResponsibleParties = responsibleParties;
        }
    }
}