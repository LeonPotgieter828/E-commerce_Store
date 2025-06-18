namespace Store.Models.ViewModels
{
    public class CartViewModel
    {
        public List<ProductTable> Products { get; set; }
        public double Total { get; set; }
        public List<int> Quantity { get; set; }
    }
}
