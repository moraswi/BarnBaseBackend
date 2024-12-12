namespace BarnBase.Models
{
    public class Farm
    {
        public int Id { get; set; }

        public int? userId { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
