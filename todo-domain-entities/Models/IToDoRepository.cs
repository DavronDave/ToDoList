using System;
using System.Collections.Generic;
using System.Text;

namespace todo_domain_entities.Models
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> toDoItems { get; }
        IEnumerable<ToDoItem> GetByCategory(Category category);
        IEnumerable<ToDoItem> GetToday();
        IEnumerable<ToDoItem> GetToDoItems();
        ToDoItem GetToDo(int id);

        void Create(ToDoItem toDoItem);
        void Delete(int id);
        void Update(ToDoItem toDoItem);

    }
}
