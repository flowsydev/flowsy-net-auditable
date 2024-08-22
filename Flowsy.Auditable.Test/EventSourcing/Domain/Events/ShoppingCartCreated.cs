namespace Flowsy.Auditable.Test.EventSourcing.Domain.Events;

public class ShoppingCartCreated : ShoppingCartEvent
{
    public ShoppingCartCreated(AuditableOperation operation, string shoppingCartId, string ownerUserAccountId)
        : base(operation, shoppingCartId)
    {
        OwnerUserAccountId = ownerUserAccountId;
    }
    public string OwnerUserAccountId { get; private set; }
}