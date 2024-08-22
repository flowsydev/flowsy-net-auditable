namespace Flowsy.Auditable.Test.EventSourcing.Domain.Events;

public abstract class ShoppingCartEvent : DomainEvent
{
    protected ShoppingCartEvent(AuditableOperation operation, string shoppingCartId) : base(operation)
    {
        ShoppingCartId = shoppingCartId;
    }
    
    public string ShoppingCartId { get; private set; }
}