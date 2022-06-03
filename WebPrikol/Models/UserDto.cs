using System.ComponentModel.DataAnnotations;

namespace WebPrikol.Models
{
    public class UserDto
    {
        [Key]
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? PhoneNumber { get; set; }
        public User? User { get; set; }
    }
}
