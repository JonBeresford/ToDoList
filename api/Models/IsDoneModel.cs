using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class IsDoneModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsDone { get; set; }
    }
}