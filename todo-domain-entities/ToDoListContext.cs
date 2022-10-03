using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using todo_domain_entities.Models;

namespace todo_domain_entities
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            :base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoItem> toDoItems { get; set; }

    }
}
