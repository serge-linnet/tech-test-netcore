using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemCreateFields
    {
        public int TodoListId { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string TodoListTitle { get; set; }

        [Display(Name = "Responsible Party")]
        public string ResponsiblePartyId { get; set; }
        
        public IEnumerable<SelectListItem> ResponsibleParties { get; } = new List<SelectListItem>();

        public Importance Importance { get; set; } = Importance.Medium;

        public TodoItemCreateFields() { }

        public TodoItemCreateFields(int todoListId, string todoListTitle, string responsiblePartyId, IEnumerable<SelectListItem> responsibleParties)
        {
            TodoListId = todoListId;
            TodoListTitle = todoListTitle;
            ResponsiblePartyId = responsiblePartyId;
            ResponsibleParties = responsibleParties;
        }
    }
}