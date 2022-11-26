

using System.ComponentModel.DataAnnotations;

namespace Storage
{
    public class Procedur
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public int Price { get; set; }
        public TimeSpan Time { get; set; }
        public List<Record>? Records { get; set; }

    }
}
