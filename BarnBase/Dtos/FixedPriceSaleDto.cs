namespace BarnBase.Dtos
{
    public class FixedPriceSaleDto
    {
        public int CowId { get; set; }

        public double Amount { get; set; } = 0;

        public String FarmName { get; set; }

        public String FarmLocation { get; set; }

        public String Breed { get; set; }

        public String Gender { get; set; }

        public String TagNo { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime? AvailableUntil { get; set; }

    }
}
