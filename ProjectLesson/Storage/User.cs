

using System.ComponentModel.DataAnnotations;

namespace Storage
{
   public class User
    {
        [Key]
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(20)]
        public string? Name { get; set; }
        [MaxLength(20)]
        public string? LastName { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<Record>? Records { get; set; }
    }
}
