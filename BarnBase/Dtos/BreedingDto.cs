namespace BarnBase.Dtos
{
    public class BreedingDto
    {
        public string Category { get; set; }

        public int Age { get; set; }

        public int CowId { get; set; }

        public int DaysLeft { get; set; }

        public int UserId { get; set; }

        public DateTime? BreedingDate { get; set; }

        public string CowTagNo { get; set; }
    }
}
