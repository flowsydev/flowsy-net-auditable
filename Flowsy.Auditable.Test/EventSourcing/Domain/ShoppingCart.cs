using Flowsy.Auditable.Test.EventSourcing.Domain.Events;

namespace Flowsy.Auditable.Test.EventSourcing.Domain;

public sealed class ShoppingCart : AggregateRoot
{
    private readonly AuditableOperationContext _operationContext;
    
    public ShoppingCart(AuditableOperationContext operationContext)
    {
        _operationContext = operationContext;
    }
    
    public string ShoppingCartId { get; private set; } = string.Empty;
    public string OwnerUserAccountId { get; private set; } = string.Empty;

    private readonly List<ShoppingCartItem> _items = [];
    public IEnumerable<ShoppingCartItem> Items => _items;
    
    public decimal Total => _items.Sum(i => i.ItemPrice);

    protected override void Apply(DomainEvent @event)
    {
        switch (@event)
        {
            case ShoppingCartCreated e:
                ShoppingCartId = e.ShoppingCartId;
                OwnerUserAccountId = e.OwnerUserAccountId;
                Creation = e.Operation;
                break;

            case ShoppingCartItemAdded e:
            {
                var item = _items.FirstOrDefault(i => i.ProductId == e.ProductId);
                if (item is not null)
                {
                    item.UpdateQuantity(item.Quantity + e.Quantity);
                    
                    if (item.ProductPrice != e.ProductPrice)
                        item.ChangePrice(e.ProductPrice);
                }
                else
                {
                    _items.Add(new ShoppingCartItem(
                        $"scitm_{Guid.NewGuid()}",
                        e.ProductId, 
                        e.ProductName,
                        e.ProductPrice,
                        e.Quantity
                    ));
                }
                LastMutation = e.Operation;
            }
                break;

            case ShoppingCartItemRemoved e:
            {
                var item = _items.First(i => i.ProductId == e.ProductId);
                item.UpdateQuantity(item.Quantity - e.Quantity);
                if (item.Quantity == 0)
                    _items.Remove(item);
                
                LastMutation = e.Operation;
            }
                break;
        }
    }
    
    public void Create(string ownerUserAccountId)
    {
        ApplyChange(new ShoppingCartCreated(
            _operationContext.CreateOperation(AuditableOperationType.Creation), 
            $"sc_{Guid.NewGuid()}",
            ownerUserAccountId
        ));
    }

    public void AddItem(Product product, double quantity)
    {
        var otherItems = Items.Where(i => i.ProductId != product.ProductId);
        var item = Items.FirstOrDefault(i => i.ProductId == product.ProductId);
        var currentQuantity = item?.Quantity ?? 0;
        var finalQuantity = currentQuantity + quantity;
        var cartTotal = otherItems.Sum(i => i.ItemPrice) + (product.Price * (decimal) finalQuantity);
        
        ApplyChange(new ShoppingCartItemAdded(
            _operationContext.CreateOperation(AuditableOperationType.Creation),
            ShoppingCartId,
            product.ProductId,
            product.Name,
            product.Price,
            quantity,
            cartTotal
            ));
    }
    
    public void RemoveItem(string productId, double quantity)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item is null)
            return;
        
        var otherItems = Items.Where(i => i.ProductId != productId);
        var currentQuantity = item.Quantity;
        var finalQuantity = currentQuantity - quantity;
        var cartTotal = otherItems.Sum(i => i.ItemPrice) + (item.ProductPrice * (decimal) finalQuantity);
        
        ApplyChange(new ShoppingCartItemRemoved(
            _operationContext.CreateOperation(AuditableOperationType.Mutation),
            ShoppingCartId,
            item.ProductId,
            item.ProductName,
            item.ProductPrice,
            item.ItemPrice,
            quantity,
            cartTotal
        ));
    }
}