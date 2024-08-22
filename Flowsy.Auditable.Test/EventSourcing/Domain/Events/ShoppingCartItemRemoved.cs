namespace Flowsy.Auditable.Test.EventSourcing.Domain.Events;

public sealed class ShoppingCartItemRemoved : ShoppingCartEvent
{
    public ShoppingCartItemRemoved(AuditableOperation operation, string shoppingCartId, string productId, string productName, decimal productPrice, decimal itemPrice, double quantity, decimal cartTotal) : base(operation, shoppingCartId)
    {
        ProductId = productId;
        ProductName = productName;
        ProductPrice = productPrice;
        ItemPrice = itemPrice;
        Quantity = quantity;
        CartTotal = cartTotal;
    }

    public string ProductId { get; }
    public string ProductName { get; }
    public decimal ProductPrice { get; }
    public decimal ItemPrice { get; }
    public double Quantity { get; }
    public decimal CartTotal { get; }
}