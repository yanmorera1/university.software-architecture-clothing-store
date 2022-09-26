using ClothingStore.Domain.Common;

namespace ClothingStore.Domain
{
    public class Claim : Entity
    {
        public string Message { get; set; }
        public string Email { get; set; }
        public string Names { get; set; }
        public int RelatedProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
