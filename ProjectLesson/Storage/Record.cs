

using System.ComponentModel.DataAnnotations;

namespace Storage
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string UserPhone { get; set; }
        public DateTime DateTime { get; set; }
        public int ProcedurId { get; set; }
        public bool IsApprove { get; set; }
        public User? User { get; set; }
        public Procedur? Procedur { get; set; }
    }
}
