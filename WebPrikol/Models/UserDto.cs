using System.ComponentModel.DataAnnotations;

namespace WebPrikol.Models
{
    public class UserDto
    {
        [Key]
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public int? Password { get; set; }
        public User? User { get; set; }
    }
}
