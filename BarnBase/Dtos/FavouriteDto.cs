using BarnBase.Models;

namespace BarnBase.Dtos
{
    public class FavouriteDto
    {
        public int UserId { get; set; }

        public int FixedPriceSaleId { get; set; }

        public FixedPriceSale FixedPriceSale { get; set; }

        //public bool Favourite { get; set; }
    }
}
