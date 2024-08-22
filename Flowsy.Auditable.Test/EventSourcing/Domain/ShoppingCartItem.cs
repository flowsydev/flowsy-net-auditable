namespace Flowsy.Auditable.Test.EventSourcing.Domain;

public sealed class ShoppingCartItem
{
    public ShoppingCartItem(string shoppingCartItemId, string productId, string productName, decimal productPrice, double quantity)
    {
        ShoppingCartItemId = shoppingCartItemId;
        ProductId = productId;
        ProductName = productName;
        ProductPrice = productPrice;
        Quantity = quantity;
    }

    public string ShoppingCartItemId { get; private set; }
    public string ProductId { get; private set; }
    public string ProductName { get; private set; }
    public decimal ProductPrice { get; private set; }
    public double Quantity { get; private set; }
    public decimal ItemPrice => ((decimal) Quantity) * ProductPrice;
    
    public void UpdateQuantity(double quantity)
    {
        Quantity = quantity;
    }

    public void ChangePrice(decimal price)
    {
        ProductPrice = price;
    }
}