using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Todo.Models.Identity;

namespace Todo.Data.Entities
{
    public class TodoList
    {
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public ApplicationUser Owner { get; set; }

        public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();

        protected TodoList() { }

        public TodoList(ApplicationUser owner, string title)
        {
            Owner = owner;
            Title = title;
        }
    }
}