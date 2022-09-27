using ClothingStore.Domain.Common;

namespace ClothingStore.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int SizeId { get; set; }
        public bool Available { get; set; }
        public virtual Size Size { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
