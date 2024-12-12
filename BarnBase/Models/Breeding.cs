namespace BarnBase.Models
{
    public class Breeding
    {
        public int Id { get; set; }

        public string? Category { get; set; }

        public int? Age { get; set; }

        public int? AnimalId { get; set; }

        public string? AnimalTagNo { get; set; }

        public int? DaysLeft { get; set; }

        public int? UserId { get; set; }

        public DateTime? BreedingDate { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
    
}
