using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.DataLayer.DTOs.ProductOrder
{
    public class UserOpenOrderDTO
    {
        public long UserId { get; set; }
        public string Description { get; set; }
        public List<UserOpenOrderDetailItemDTO> Details { get; set; }

        public int GetTotalPrice()
        {
            return Details.Sum(x => (x.ProductPrice + x.ProductColorPrice) * x.Count);
        }
    }

}
