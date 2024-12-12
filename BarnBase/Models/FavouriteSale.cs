namespace BarnBase.Models
{
    public class FavouriteSale
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? FixedPriceSaleId { get; set; }

        public FixedPriceSale FixedPriceSale { get; set; }

    }
}
