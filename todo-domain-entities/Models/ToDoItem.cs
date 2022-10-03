using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace todo_domain_entities.Models
{
    public class ToDoItem
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public Status GetStatus { get; set; }
        public bool Show { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
    public enum Status { 
        Completed,
        InProgress,
        NotStarted,
        NotDone
    }
}
