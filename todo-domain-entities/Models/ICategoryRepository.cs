using System;
using System.Collections.Generic;
using System.Text;

namespace todo_domain_entities.Models
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Delete(int id);
        void Update(Category category);
        IEnumerable<Category> GetCategories();
        int Count();
        Category GetCategory(int id);
    }
}
