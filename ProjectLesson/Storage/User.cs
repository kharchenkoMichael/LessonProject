

namespace Storage
{
   public class User
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
