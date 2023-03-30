using api.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Message
{
    public class ToDoItemModel : IToDoItem, IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        public bool IsDone { get; set; }     



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var results = new List<ValidationResult>();

            // some other random test
            if (string.IsNullOrEmpty(Name))
            {
                results.Add(new ValidationResult("Name must be populated"));
            }                     
         

            if (Description.Length > 150)
            {
                results.Add(new ValidationResult("Description can only be 160 characters maximum"));
            }

            return results;
        }
    }
}