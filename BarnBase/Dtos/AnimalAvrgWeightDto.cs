namespace BarnBase.Dtos
{
    public class AnimalAvrgWeightDto
    {
        public int Id { get; set; }

        public int FarmId { get; set; }

        public string Sex { get; set; } = string.Empty;

        public double? AverageWeight { get; set; }

    }
}
