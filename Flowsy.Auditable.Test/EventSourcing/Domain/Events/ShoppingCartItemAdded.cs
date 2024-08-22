namespace Flowsy.Auditable.Test.EventSourcing.Domain.Events;

public class ShoppingCartItemAdded : ShoppingCartEvent
{
    public ShoppingCartItemAdded(
        AuditableOperation operation,
        string shoppingCartId,
        string productId,
        string productName,
        decimal productPrice,
        double quantity,
        decimal cartTotal
        ) : base(operation, shoppingCartId)
    {
        ProductId = productId;
        ProductName = productName;
        ProductPrice = productPrice;
        Quantity = quantity;
        CartTotal = cartTotal;
    }

    public string ProductId { get; }
    public string ProductName { get; }
    public decimal ProductPrice { get; }
    public double Quantity { get; }
    public decimal ItemTotal => ((decimal)Quantity) * ProductPrice;
    public decimal CartTotal { get; }
}