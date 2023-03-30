using System;
using System.ComponentModel.DataAnnotations;
using api.Common;

namespace api.Entities
{
    public class ToDoItemEntity : IToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }
       
    }
}
