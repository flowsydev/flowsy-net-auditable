using Xunit.Abstractions;

namespace Flowsy.Auditable.Test;

public class OperationContextTest
{
    private readonly ITestOutputHelper _output;

    public OperationContextTest(ITestOutputHelper output)
    {
        _output = output;
    }

    public static IEnumerable<object[]> TestData() => [
        [
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36", 
            AuditableUserAgentFamily.Chrome,
            AuditableOperatingSystemFamily.Windows,
            AuditableDeviceFamily.Desktop
        ],
        [
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Firefox/89.0",
            AuditableUserAgentFamily.Firefox,
            AuditableOperatingSystemFamily.Apple,
            AuditableDeviceFamily.Desktop
        ],
        [
            "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:89.0) Gecko/20100101 Firefox/89.0",
            AuditableUserAgentFamily.Firefox,
            AuditableOperatingSystemFamily.Linux,
            AuditableDeviceFamily.Desktop
        ],
        [
            "Mozilla/5.0 (Linux; Android 11; Pixel 4 XL Build/RQ1A.210205.004) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.105 Mobile Safari/537.36",
            AuditableUserAgentFamily.Chrome,
            AuditableOperatingSystemFamily.Linux,
            AuditableDeviceFamily.Mobile
        ],
        [
            "Mozilla/5.0 (iPhone; CPU iPhone OS 14_6 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.6 Mobile/15E148 Safari/604.1",
            AuditableUserAgentFamily.Safari,
            AuditableOperatingSystemFamily.Apple,
            AuditableDeviceFamily.Mobile
        ]
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void Creates_Operation_Context_From_User_Agent(
        string userAgent,
        AuditableUserAgentFamily expectedUserAgentFamily,
        AuditableOperatingSystemFamily expectedOperatingSystemFamily,
        AuditableDeviceFamily expectedDeviceFamily
        )
    {
        // Arrange
        var userId = Guid.NewGuid().ToString();
        var userAlias = Environment.UserName;
        var userAccountId = Guid.NewGuid().ToString();
        var userAccountAlias = $"{userAlias}@example.com";
        var applicationId = Guid.NewGuid().ToString();
        const string applicationAlias = "Some Application";
        const string originHostName = "client.example.com";
        const string originIpAddress = "192.168.1.22";

        var localDevice = new AuditableDevice(
            AuditableDeviceFamily.Server,
            "HP",
            "ProLiant DL380 Gen10",
            false,
            "server.example.com",
            "192.168.1.44",
            new AuditableOperatingSystem(
                AuditableOperatingSystemFamily.Linux,
                "Ubuntu",
                new AuditableVersion("20", "04")
                )
        );
        
        // Act
        var context = AuditableOperationContext.Create()
            .WithUser(userId, userAlias)
            .WithUserAccount(userAccountId, userAccountAlias)
            .WithUserAgent(userAgent, originHostName, originIpAddress)
            .WithLocalDevice(localDevice)
            .WithApplication(applicationId, applicationAlias, new AuditableVersion("4", "1", "22"))
            .Build();
        
        _output.WriteLine(context.ToString());

        // Assert
        Assert.Equal(expectedUserAgentFamily, context.UserAgent?.Family);
        Assert.Equal(expectedOperatingSystemFamily, context.OriginDevice.OperatingSystem.Family);
        Assert.Equal(expectedDeviceFamily, context.OriginDevice.Family);
    }
}