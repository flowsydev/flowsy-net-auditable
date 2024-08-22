namespace Flowsy.Auditable;

/// <summary>
/// Represents a builder for creating an auditable operation context.
/// </summary>
public class AuditableOperationContextBuilder
{
    private readonly AuditableOperationContext _context;
    
    internal AuditableOperationContextBuilder(AuditableOperationContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Sets the user of the auditable operation context.
    /// </summary>
    /// <param name="user">
    /// The user of the auditable operation context.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithUser(AuditablePrincipal user)
    {
        _context.User = user;
        return this;
    }
    
    /// <summary>
    /// Sets the user of the auditable operation context.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the user.
    /// </param>
    /// <param name="alias">
    /// The alias of the user.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithUser(string id, string alias)
    {
        WithUser(new AuditablePrincipal(id, alias));
        return this;
    }

    /// <summary>
    /// Sets the user account of the auditable operation context.
    /// </summary>
    /// <param name="userAccount">
    /// The user account of the auditable operation context.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithUserAccount(AuditablePrincipal userAccount)
    {
        _context.UserAccount = userAccount;
        return this;
    }
    
    /// <summary>
    /// Sets the user account of the auditable operation context.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the user account.
    /// </param>
    /// <param name="alias">
    /// The alias of the user account.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithUserAccount(string id, string alias)
    {
        WithUserAccount(new AuditablePrincipal(id, alias));
        return this;
    }
    
    /// <summary>
    /// Sets the user agent of the auditable operation context.
    /// </summary>
    /// <param name="userAgent">
    /// The user agent of the auditable operation context.
    /// </param>
    /// <param name="hostName">
    /// The host name of the user agent.
    /// </param>
    /// <param name="ipAddress">
    /// The IP address of the user agent.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithUserAgent(string userAgent, string? hostName = null, string? ipAddress = null)
    {
        var ua = AuditableUserAgentParser.Parse(userAgent, hostName, ipAddress);
        
        _context.UserAgent = ua;
        _context.OriginDevice = ua.Device;
        
        return this;
    }
    
    /// <summary>
    /// Sets the application of the auditable operation context.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the application.
    /// </param>
    /// <param name="alias">
    /// The alias of the application.
    /// </param>
    /// <param name="version">
    /// The version of the application.
    /// </param>
    /// <param name="details">
    /// The details of the application.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithApplication(string id, string alias, AuditableVersion? version = null, IReadOnlyDictionary<string, object?>? details = null)
    {
        _context.Application = new AuditableApplication(id, alias, version, details);
        return this;
    }

    /// <summary>
    /// Sets the application of the auditable operation context.
    /// </summary>
    /// <param name="family">
    /// The family of the application.
    /// </param>
    /// <param name="brand">
    /// The brand of the application.
    /// </param>
    /// <param name="model">
    /// The model of the application.
    /// </param>
    /// <param name="isSpider">
    /// Indicates whether the application is a bot or spider.
    /// A spider is a program that automatically crawls the web and indexes web pages.
    /// </param>
    /// <param name="hostName">
    /// The host name of the application.
    /// </param>
    /// <param name="ipAddress">
    /// The IP address of the application.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithOriginDevice(
        AuditableDeviceFamily family,
        string? brand = null,
        string? model = null,
        bool isSpider = false,
        string? hostName = null,
        string? ipAddress = null
        )
    {
        _context.OriginDevice = new AuditableDevice(
            family,
            brand,
            model,
            isSpider,
            hostName,
            ipAddress
        );
        return this;
    }
    
    /// <summary>
    /// Sets the local device of the auditable operation context.
    /// </summary>
    /// <param name="localDevice">
    /// The local device of the auditable operation context.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithLocalDevice(AuditableDevice localDevice)
    {
        _context.LocalDevice = localDevice;
        return this;
    }
    
    /// <summary>
    /// Sets the local device of the auditable operation context.
    /// </summary>
    /// <param name="family">
    /// The family of the device.
    /// </param>
    /// <param name="brand">
    /// The brand of the device.
    /// </param>
    /// <param name="model">
    /// The model of the device.
    /// </param>
    /// <param name="isSpider">
    /// Indicates whether the device is a bot or spider.
    /// A spider is a program that automatically crawls the web and indexes web pages.
    /// </param>
    /// <param name="hostName">
    /// The host name of the device.
    /// </param>
    /// <param name="ipAddress">
    /// The IP address of the device.
    /// </param>
    /// <returns>
    /// The current instance of the <see cref="AuditableOperationContextBuilder"/> class.
    /// </returns>
    public AuditableOperationContextBuilder WithLocalDevice(
        AuditableDeviceFamily family,
        string? brand = null,
        string? model = null,
        bool isSpider = false,
        string? hostName = null,
        string? ipAddress = null
        )
        => WithLocalDevice(new AuditableDevice(family, brand, model, isSpider, hostName, ipAddress));

    /// <summary>
    /// Builds the auditable operation context based on the previously set properties.
    /// </summary>
    /// <returns>
    /// The auditable operation context.
    /// </returns>
    public AuditableOperationContext Build() => _context;
}