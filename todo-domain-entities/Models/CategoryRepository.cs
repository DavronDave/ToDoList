using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace todo_domain_entities.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private ToDoListContext _context;

        public CategoryRepository( ToDoListContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(new Category { id = id });
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Category GetCategory(int id)
        {
              return _context.Categories.FirstOrDefault(x => x.id==id);
      
        }

        public int Count() => _context.Categories.Count();
    }
}
