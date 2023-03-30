using System.ComponentModel.DataAnnotations;

namespace SolidProductApi.Models
{
    public class Keyboard : Product
    {
        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Features { get; set; } = string.Empty;
    }
}
