using Flowsy.Auditable.Test.EventSourcing.Domain;
using Xunit.Abstractions;

namespace Flowsy.Auditable.Test;

public class ShoppingCartTest
{
    private readonly AuditableOperationContext _operationContext;
    private readonly ITestOutputHelper _output;

    public ShoppingCartTest(ITestOutputHelper output)
    {
        var userId = Guid.NewGuid().ToString();
        var userAlias = Environment.UserName;
        var userAccountId = Guid.NewGuid().ToString();
        var userAccountAlias = $"{userAlias}@example.com";
        var applicationId = Guid.NewGuid().ToString();
        const string applicationAlias = "Some Application";
        const string userAgent = "Mozilla/5.0 (Linux; Android 11; Pixel 4 XL Build/RQ1A.210205.004) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.105 Mobile Safari/537.36";
        const string originHostName = "client.example.com";
        const string originIpAddress = "192.168.1.22";

        var localDevice = new AuditableDevice(
            AuditableDeviceFamily.Server,
            "HP",
            "ProLiant DL380 Gen10",
            false,
            "server.example.com",
            "192.168.1.44",
            new AuditableOperatingSystem(AuditableOperatingSystemFamily.Linux, "Ubuntu", new AuditableVersion("20", "04", label: "LTS"))
            );
            
        _operationContext = AuditableOperationContext.Create()
            .WithUser(userId, userAlias)
            .WithUserAccount(userAccountId, userAccountAlias)
            .WithUserAgent(userAgent, originHostName, originIpAddress)
            .WithApplication(applicationId, applicationAlias, new AuditableVersion("4", "1", "22"))
            .WithLocalDevice(localDevice)
            .Build();
        
        _output = output;
    }

    [Fact]
    public void Shopping_Cart_Is_Processed_Using_Operation_Context()
    {
        // Arrange
        var ownerUserAccountId = $"usracc_{Guid.NewGuid()}";
        var product1 = new Product($"prd_{Guid.NewGuid()}", "Product One", "The first product", 100.00m);
        var product2 = new Product($"prd_{Guid.NewGuid()}", "Product Two", "The second product", 200.00m);
        var product3 = new Product($"prd_{Guid.NewGuid()}", "Product Three", "The third product", 300.00m);

        // Act
        var shoppingCart = new ShoppingCart(_operationContext);
        
        shoppingCart.Create(ownerUserAccountId);
        
        shoppingCart.AddItem(product1, 1);
        shoppingCart.AddItem(product2, 1);
        shoppingCart.AddItem(product1, 3);
        shoppingCart.AddItem(product3, 1);
        shoppingCart.RemoveItem(product1.ProductId, 1);
        
        foreach (var e in shoppingCart.Events)
            _output.WriteLine(e.ToString());
       
        // Assert
        Assert.Equal(6, shoppingCart.Events.Count());
        Assert.Equal(3, shoppingCart.Items.Count());
        Assert.Equal(800m, shoppingCart.Total);
    }
}