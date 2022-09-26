using ClothingStore.Domain.Common;

namespace ClothingStore.Domain
{
    public class Order : Entity
    {
        public decimal TotalPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
