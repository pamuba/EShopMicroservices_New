namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            
        }
        public ShoppingCart(string username)
        {
            UserName = username;
        }
        public string? UserName { get; set; } = default;
        public List<ShoppingCartItem> Items { get; set; } = new();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    }
}
