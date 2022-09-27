namespace ClothingStore.Application.Models.ViewModels
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int SizeId { get; set; }
        public bool Available { get; set; }
        public int TypeId { get; set; }
    }
}
