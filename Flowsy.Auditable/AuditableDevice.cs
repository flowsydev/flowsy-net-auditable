using System.Collections.ObjectModel;
using System.Text;

namespace Flowsy.Auditable;

/// <summary>
/// Represents auditable information about a device.
/// </summary>
public sealed class AuditableDevice : AuditableTrail
{
    /// <summary>
    /// Initializes an empty instance of the <see cref="AuditableDevice"/> class.
    /// </summary>
    public AuditableDevice() : this(AuditableDeviceFamily.Unknown, null, null, false, string.Empty, string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableDevice"/> class.
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
    /// <param name="isBot">
    /// Indicates whether the device is a bot or spider.
    /// A spider is a program that automatically crawls the web and indexes web pages.
    /// </param>
    /// <param name="hostName">
    /// The host name of the device.
    /// </param>
    /// <param name="ipAddress">
    /// The IP address of the device.
    /// </param>
    /// <param name="operatingSystem">
    /// The operating system of the device.
    /// </param>
    public AuditableDevice(
        AuditableDeviceFamily family,
        string? brand,
        string? model,
        bool isBot,
        string? hostName = null,
        string? ipAddress = null,
        AuditableOperatingSystem? operatingSystem = null
        )
        : this(family, brand, model, isBot, hostName, ipAddress, operatingSystem ?? new AuditableOperatingSystem(), new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>()))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditableDevice"/> class.
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
    /// <param name="isBot">
    /// Indicates whether the device is a bot or spider.
    /// A spider is a program that automatically crawls the web and indexes web pages.
    /// </param>
    /// <param name="hostName">
    /// The host name of the device.
    /// </param>
    /// <param name="ipAddress">
    /// The IP address of the device.
    /// </param>
    /// <param name="operatingSystem">
    /// The operating system of the device.
    /// </param>
    /// <param name="details">
    /// Additional details about the device.
    /// </param>
    public AuditableDevice(
        AuditableDeviceFamily family,
        string? brand,
        string? model,
        bool isBot,
        string? hostName,
        string? ipAddress,
        AuditableOperatingSystem operatingSystem,
        IReadOnlyDictionary<string, object?> details
        ) : base(details)
    {
        Family = family;
        Brand = brand;
        Model = model;
        IsBot = isBot;
        HostName = hostName;
        IpAddress = ipAddress;
        OperatingSystem = operatingSystem;
    }

    /// <summary>
    /// The family of the device.
    /// </summary>
    public AuditableDeviceFamily Family { get; private set; }
    
    /// <summary>
    /// The brand of the device.
    /// </summary>
    public string? Brand { get; private set; }
    
    /// <summary>
    /// The model of the device.
    /// </summary>
    public string? Model { get; private set; }
    
    /// <summary>
    /// Indicates whether the device is a bot or spider.
    /// A spider is a program that automatically crawls the web and indexes web pages.
    /// </summary>
    public bool IsBot { get; private set; }
    
    /// <summary>
    /// The host name of the device.
    /// </summary>
    public string? HostName { get; private set; }
    
    /// <summary>
    /// The IP address of the device.
    /// </summary>
    public string? IpAddress { get; private set; }
    
    /// <summary>
    /// The operating system of the device.
    /// </summary>
    public AuditableOperatingSystem OperatingSystem { get; private set; }

    /// <summary>
    /// Returns a string that represents the device object.
    /// </summary>
    /// <returns>
    /// A string that represents the device object.
    /// </returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        
        stringBuilder.Append(Family);
        
        if (!string.IsNullOrWhiteSpace(Brand))
            stringBuilder.Append($" {Brand}");
        
        if (!string.IsNullOrWhiteSpace(Model))
            stringBuilder.Append($" {Model}");
        
        if (!string.IsNullOrEmpty(HostName) && HostName != IpAddress)
            stringBuilder.Append($", {HostName}");
        
        if (!string.IsNullOrEmpty(IpAddress))
            stringBuilder.Append($", {IpAddress}");
        
        stringBuilder.Append($", {OperatingSystem}");

        return stringBuilder.ToString();
    }
}