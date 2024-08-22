namespace Flowsy.Auditable.Test.EventSourcing.Domain;

public sealed class Product
{
    public Product() : this(string.Empty, string.Empty, string.Empty, 0.00m)
    {
    }

    public Product(string productId, string name, string description, decimal price)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Price = price;
    }

    public string ProductId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
}