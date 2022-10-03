using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_domain_entities.Models
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }

        public List<ToDoItem> toDoItems { get; set; }

    }
}
