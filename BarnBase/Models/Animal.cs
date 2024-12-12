namespace BarnBase.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string TagNo { get; set; } = string.Empty;

        public int FarmId { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Breed { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public DateTime DateOfAcquisition { get; set; }

        public string PreviousOwner { get; set; } = string.Empty;

        public double PurchasePrice { get; set; }

        public string SireId { get; set; } = string.Empty;

        public string SireName { get; set; } = string.Empty;

        public string DamId { get; set; } = string.Empty;

        public string DamName { get; set; } = string.Empty;

        public double BirthWeight { get; set; }

        public double CurrentWeight { get; set; }

        public string AssignedGroup { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;

        public string FosterDam { get; set; } = string.Empty;

        public string Owner { get; set; } = string.Empty;

        public int SurrogateId { get; set; }

        public string SurrogateName { get; set; } = string.Empty;

        public double DamWeight { get; set; }

        public string Comment { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
