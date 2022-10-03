using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace todo_domain_entities.Models
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoListContext _context;

        public ToDoRepository(ToDoListContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoItem> toDoItems => _context.toDoItems.Include(x => x.Category).ToList();

        public void Create(ToDoItem toDoItem)
        {
            toDoItem.id = 0;
            _context.toDoItems.Add(toDoItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.toDoItems.Remove(new ToDoItem { id = id });
            _context.SaveChanges();
        }

        public IEnumerable<ToDoItem> GetByCategory(Category category)
        {
           return _context.toDoItems.Where(x => x.CategoryId == category.id).Include(x => x.Category).ToList();
        }

        public IEnumerable<ToDoItem> GetToday()
        {
            return _context.toDoItems.Where(x => x.DueDate.Year == DateTime.Now.Year && x.DueDate.Month==DateTime.Now.Month && x.DueDate.Day==DateTime.Now.Day)
                .Include(x=>x.Category).ToList();
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _context.toDoItems.ToList();
        }

        public ToDoItem GetToDo(int id)
        {
            return _context.toDoItems.Include(x => x.Category).FirstOrDefault(x => x.id == id);
        }

        public void Update(ToDoItem toDoItem)
        {
            _context.Entry(toDoItem).State=EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
