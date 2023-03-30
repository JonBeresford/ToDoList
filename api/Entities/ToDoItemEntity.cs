using System;
using System.ComponentModel.DataAnnotations;
using api.Common;

namespace api.Entities
{
    public class ToDoItemEntity : IToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string ToPhoneNumber { get; set; }

        [Required]
        [MaxLength(160)]
        public string Message { get; set; }

        [Required]
        public DateTime SentDate { get; set; }
    }
}
