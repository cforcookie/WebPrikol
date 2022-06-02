using System.ComponentModel.DataAnnotations;

namespace WebPrikol.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public List<Basket>? BasketsList { get; set; }
        public UserDto? UserDto { get; set; }
        public int? UserDtoForeiginKey { get; set; }
    }
}
