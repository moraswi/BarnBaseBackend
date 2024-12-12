namespace BarnBase.Models
{
    public class Weight
    {
        public int Id { get; set; }

        public int? Age { get; set; }

        public double? AnimalWeight { get; set; }

        public int? AnimalId { get; set; }

        public string? Category { get; set; }

        public string? MotherTagNo { get; set; }
        
        public DateTime? CreatedAt { get; set; }

    }
}
