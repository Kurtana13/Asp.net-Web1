using System.ComponentModel.DataAnnotations;

namespace WebProjectSaba.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
