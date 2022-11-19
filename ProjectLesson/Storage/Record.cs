

namespace Storage
{
    public class Record
    {
        public int Id { get; set; } 
        public string UserPhone { get; set; }
        public DateTime DateTime { get; set; }
        public string Procedur { get; set; }
        public bool IsApproved { get; set; }
    }
}
