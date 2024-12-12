namespace BarnBase.Models
{
    public class NoteTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

    }
}
