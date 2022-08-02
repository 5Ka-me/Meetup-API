namespace DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Theme { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Organizer { get; set; } = null!;
        public DateTime Start { get; set; }
        public string Place { get; set; } = null!;
    }
}
