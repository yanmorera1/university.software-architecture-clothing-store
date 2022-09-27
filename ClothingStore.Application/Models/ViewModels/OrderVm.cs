namespace ClothingStore.Application.Models.ViewModels
{
    public class OrderVm
    {
        public List<ProductVm> RelatedProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
